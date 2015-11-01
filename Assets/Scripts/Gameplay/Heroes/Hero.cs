// Created 30.10.2015
// Modified by Александр 01.11.2015 at 12:32

namespace Assets.Scripts.Gameplay.Heroes {
    #region References

    using Engine.Moving;
    using UnityEngine;

    #endregion

    [RequireComponent(typeof (Animator))]
    internal class Hero : Movable {
        private Animator _animator;
        private bool _isJumping;

        [SerializeField]
        private Rigidbody2D _rigidbody;

        private float _speed;

        private Stand[] _stands;

        public override void Jump(float jumpForce) {
            if (!_isJumping) {
                _animator.SetTrigger("jump");
                _rigidbody.velocity += new Vector2(0, jumpForce);
                _isJumping = true;
            }
        }

        public override void Run(float speed) {
            _speed = speed;
        }

        private void FixedUpdate() {
            _rigidbody.velocity = new Vector2(_speed, _rigidbody.velocity.y);
        }

        protected override void Awake() {
            base.Awake();
            _animator = GetComponent<Animator>();
            foreach (var stand in GetComponentsInChildren<Stand>()) {
                stand.Grounded += OnGrounded;
            }
        }

        private void OnGrounded() {
            _isJumping = false;
            _animator.SetTrigger("run");
        }
    }
}