// Created 20.10.2015
// Modified by  20.01.2016 at 13:47

namespace Assets.Scripts.Gameplay.Heroes {
    #region References

    using System;
    using Engine;
    using Engine.Extensions;
    using Engine.Moving;
    using JumpEngines;
    using Obstacles;
    using RunEngines;
    using UnityEngine;

    #endregion

    [RequireComponent(typeof (MovingController))]
    internal class Hero : MonoBehaviourBase, IMovable {
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

        #region Interface

        public void Jump(float jumpForce) {
            if (Grounded && !_isStubmled) {
                _jumpingEngine.Jump(jumpForce);
            }
        }

        public float NominalSpeed { get; private set; }

        public void Run(float speed) {
            NominalSpeed = speed;
        }


        public virtual void Die() {
            Stop();
            Died.SafeInvoke(this, new HeroEventArgs(this));
        }

        public virtual void Win() {
            Stop();
        }

        public Vector2 Speed {
            get { return _runningEngine.Speed; }
        }

        #region Events

        public event EventHandler<HeroEventArgs> Died;

        #endregion

        #endregion

        private bool _isStubmled;
        private IMovingController _movingController;


        protected bool Grounded { get; private set; }

        private void FixedUpdate() {
            Grounded = Physics2D.OverlapCircle(_groundCheck.position, 10f, _groundLayer);
            Run();
        }

        private void Stop() {
            NominalSpeed = 0;
        }

        protected virtual void Run() {
            if (!_isStubmled) {
                _runningEngine.Run(NominalSpeed);
            }
        }


        protected virtual void Stumble(int damage, Action callback) {
            _isStubmled = true;
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            if (_isStubmled) {
                return;
            }
            var danger = collision.gameObject.GetInterfaceComponent<IDanger>();
            if (danger != null) {
                Stumble(danger.Damage, OnStumbleEnded);
            }
        }

        private void OnStumbleEnded() {
            _isStubmled = false;
        }

        protected override void Awake() {
            base.Awake();
            _movingController = GetInterfaceComponent<IMovingController>();
            _movingController.RegisterMovable(this);
        }

        public class HeroEventArgs : EventArgs {
            public HeroEventArgs(Hero hero) {
                Hero = hero;
            }

            public Hero Hero { get; private set; }
        }
    }
}