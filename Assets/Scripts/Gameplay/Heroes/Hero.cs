// Created 20.10.2015
// Modified by  18.12.2015 at 16:27

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

        protected Collider2D Grounded { get; private set; }

        public override void Jump(float jumpForce) {
            if (!_isJumping) {
                //_rigidbody.velocity = new Vector2(_rigidbody.velocity.y, jumpForce);
                _jumpingEngine.Jump(jumpForce);
                _isJumping = true;
            }
        }

        public override void Run(float speed) {
            //Speed = speed;
            _runningEngine.Run(speed);
        }

        protected virtual void FixedUpdate() {
            Grounded = Physics2D.OverlapCircle(_groundCheck.position, 35f, _groundLayer);
            _isJumping = !Grounded;
            //_rigidbody.velocity = new Vector2(Speed, _rigidbody.velocity.y);
        }

        private void Stop() {
            Speed = 0;
        }

        public virtual void Kill() {
            Stop();
        }

        public virtual void Congratulate() {
            Stop();
        }
    }
}