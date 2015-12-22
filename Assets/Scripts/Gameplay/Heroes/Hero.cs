// Created 20.10.2015
// Modified by  22.12.2015 at 10:35

namespace Assets.Scripts.Gameplay.Heroes {
    #region References

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


        private bool _isJumping;

        [SerializeField]
        private HeroJumpingEngine _jumpingEngine;

        [SerializeField]
        private HeroRunningEngine _runningEngine;

        protected float Speed { get; private set; }

        protected bool Grounded { get; private set; }

        public override void Jump(float jumpForce) {
            if (!_isJumping) {
                _jumpingEngine.Jump(jumpForce);
                _isJumping = true;
            }
        }

        public override void Run(float speed) {
            Speed = speed;
            _runningEngine.Run(speed);
        }

        protected virtual void FixedUpdate() {
            Grounded = Physics2D.OverlapCircle(_groundCheck.position, 35f, _groundLayer);
            _isJumping = !Grounded;
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