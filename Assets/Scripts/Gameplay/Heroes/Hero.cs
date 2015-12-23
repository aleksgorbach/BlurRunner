// Created 20.10.2015
// Modified by  23.12.2015 at 13:23

namespace Assets.Scripts.Gameplay.Heroes {
    #region References

    using System;
    using Engine.Moving;
    using JumpEngines;
    using RunEngines;
    using UnityEngine;

    #endregion

    internal class Hero : Movable {
        [SerializeField]
        private Transform _groundCheck;

        [SerializeField]
        private LayerMask _groundLayer;

        private float _health;


        [SerializeField]
        private HeroJumpingEngine _jumpingEngine;

        [SerializeField]
        private HeroRunningEngine _runningEngine;

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

        public void Die() {
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
            _runningEngine.Run(speed);
        }

        protected virtual void FixedUpdate() {
            Grounded = Physics2D.OverlapCircle(_groundCheck.position, 10f, _groundLayer);
        }

        private void Stop() {
            Speed = 0;
            _runningEngine.Stop();
        }

        public virtual void Kill() {
            Stop();
        }

        public virtual void Congratulate() {
            Stop();
        }
    }
}