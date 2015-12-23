// Created 20.10.2015
// Modified by  23.12.2015 at 13:23

namespace Assets.Scripts.Gameplay.Heroes {
    #region References

    using System;
    using Consts;
    using Engine.Moving;
    using JumpEngines;
    using RunEngines;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class Hero : Movable {
        #region Visible in inspector

        [SerializeField]
        private Transform _groundCheck;

        [SerializeField]
        private LayerMask _groundLayer;

        [SerializeField]
        private HeroJumpingEngine _jumpingEngine;


        [SerializeField]
        private HeroRunningEngine _runningEngine;

        #endregion

        private float _health;

        private bool _isStubmled;


        [Inject(Identifiers.Obstacles.Layer)]
        private string _obstaclesLayer;

        protected float Speed { get; private set; }

        protected bool Grounded { get; private set; }

        public float Health {
            get { return _health; }
            private set {
                _health = value;
                if (_health <= 0) {
                    Die();
                }
            }
        }

        private bool IsObstacleLayer(int layer) {
            return _obstaclesLayer == LayerMask.LayerToName(layer);
        }

        public virtual void Die() {
            var handler = Died;
            if (handler != null) {
                handler();
            }
        }

        public event Action Died;

        public override void Jump(float jumpForce) {
            if (Grounded) {
                _jumpingEngine.Jump(jumpForce);
            }
        }

        public override void Run(float speed) {
            Speed = speed;
        }

        private void FixedUpdate() {
            Grounded = Physics2D.OverlapCircle(_groundCheck.position, 10f, _groundLayer);
            if (Grounded && !_isStubmled) {
                Run();
            }
        }

        private void Stop() {
            Speed = 0;
        }

        protected virtual void Run() {
            _runningEngine.Run(Speed);
        }

        public virtual void Congratulate() {
            Stop();
        }

        protected virtual void Stumble(Action callback) {
            _isStubmled = true;
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            if (_isStubmled) {
                return;
            }
            if (IsObstacleLayer(collision.gameObject.layer)) {
                Stumble(OnStumbleEnded);
            }
        }

        private void OnStumbleEnded() {
            _isStubmled = false;
        }
    }
}