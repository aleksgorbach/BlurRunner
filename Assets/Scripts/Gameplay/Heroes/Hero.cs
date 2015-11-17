// Created 20.10.2015 
// Modified by Gorbach Alex 17.11.2015 at 15:01

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

        [SerializeField]
        private Foot _trippedFoot;

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
            if (_trippedFoot) {
                _trippedFoot.Tripped += OnTripped;
            }
        }

        private void OnTripped() {
            _animator.SetTrigger("trip");
        }

        private void OnWin() {
            var handler = Win;
            if (handler != null) {
                handler(this);
            }
        }
    }
}