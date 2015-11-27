// Created 20.10.2015
// Modified by  27.11.2015 at 13:29

namespace Assets.Scripts.Gameplay.Heroes {
    #region References

    using System;
    using Engine.Moving;
    using GameState.StateChangedSources;
    using UnityEngine;

    #endregion

    internal class Hero : Movable, IWinSource {
        [SerializeField]
        private Transform _groundCheck;

        [SerializeField]
        private LayerMask _groundLayer;


        private bool _isJumping;

        [SerializeField]
        private Rigidbody2D _rigidbody;

        protected float Speed { get; private set; }

        protected Collider2D Grounded { get; private set; }

        public event Action<IWinSource> Win;

        public override void Jump(float jumpForce) {
            if (!_isJumping) {
                //_rigidbody.velocity += new Vector2(0, jumpForce);
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.y, jumpForce);
                _isJumping = true;
            }
        }

        public override void Run(float speed) {
            Speed = speed;
        }

        protected virtual void FixedUpdate() {
            Grounded = Physics2D.OverlapCircle(_groundCheck.position, 35f, _groundLayer);
            _isJumping = !Grounded;
            _rigidbody.velocity = new Vector2(Speed, _rigidbody.velocity.y);
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


        private void OnWin() {
            var handler = Win;
            if (handler != null) {
                handler(this);
            }
        }
    }
}