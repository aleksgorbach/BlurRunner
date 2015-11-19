// Created 20.10.2015 
// Modified by Gorbach Alex 19.11.2015 at 9:38

namespace Assets.Scripts.Gameplay.Heroes {
    #region References

    using System;
    using Engine.Moving;
    using GameState.StateChangedSources;
    using UnityEngine;

    #endregion

    [RequireComponent(typeof(Animator))]
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

        public float Destination { private get; set; }

        public event Action<IWinSource> Win;

        public override void Jump(float jumpForce) {
            if (!_isJumping) {
                //_rigidbody.velocity += new Vector2(0, jumpForce);
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.y, jumpForce);
                _isJumping = true;
            }
        }

        public override void Run(float speed) {
            _speed = speed;
        }

        private void FixedUpdate() {
            bool grounded = Physics2D.OverlapCircle(_groundCheck.position, 35f, _groundLayer);
            _animator.SetBool("grounded", grounded);
            _animator.SetFloat("speed", _speed);
            _isJumping = !grounded;
            _rigidbody.velocity = new Vector2(_speed, _rigidbody.velocity.y);
            if (_rigidbody.position.x >= Destination) {
                OnWin();
            }
        }

        public void Stop() {
            _speed = 0;
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