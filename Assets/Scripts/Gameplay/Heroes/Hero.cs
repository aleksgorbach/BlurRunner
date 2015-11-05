// Created 02.11.2015
// Modified by Александр 05.11.2015 at 19:29

namespace Assets.Scripts.Gameplay.Heroes {
    #region References

    using System;
    using Engine.Moving;
    using GameState.StateChangedSources;
    using UnityEngine;

    #endregion

    [RequireComponent(typeof (Animator))]
    internal class Hero : Movable, IWinSource {
        private Animator _animator;

        [SerializeField]
        private Transform _groundCheck;

        [SerializeField]
        private LayerMask _groundLayer;

        private bool _isJumping;

        [SerializeField]
        private Rigidbody2D _rigidbody;

        private float _speed;

        private Stand[] _stands;
        public float Destination { private get; set; }

        public event Action<IWinSource> Win;

        public override void Jump(float jumpForce) {
            if (!_isJumping) {
                _rigidbody.velocity += new Vector2(0, jumpForce);
                _isJumping = true;
            }
        }

        public override void Run(float speed) {
            _speed = speed;
        }

        private void FixedUpdate() {
            bool grounded = Physics2D.OverlapCircle(_groundCheck.position, 35f, _groundLayer);
            _animator.SetBool("grounded", grounded);
            _isJumping = !grounded;
            _rigidbody.velocity = new Vector2(_speed, _rigidbody.velocity.y);
            if (_rigidbody.position.x >= Destination) {
                OnWin();
            }
        }

        protected override void Awake() {
            base.Awake();
            _animator = GetComponent<Animator>();
        }

        private void OnWin() {
            var handler = Win;
            if (handler != null) {
                handler(this);
            }
        }
    }
}