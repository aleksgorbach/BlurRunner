// Created 20.10.2015 
// Modified by Gorbach Alex 30.10.2015 at 11:18

namespace Assets.Scripts.Gameplay.Heroes {
    #region References

    using Engine;
    using Engine.Moving;
    using UnityEngine;
    using Zenject;

    #endregion

    [RequireComponent(typeof(Animator))]
    internal class Hero : MonoBehaviourBase, IMovable {
        private bool _isJumping;
        private Animator _animator;

        [SerializeField]
        private Rigidbody2D _rigidbody;

        private float _speed;

        private Stand[] _stands;

        public Vector2 Velocity {
            get {
                return _rigidbody.velocity;
            }
            set {
                _rigidbody.velocity = value;
            }
        }

        public void Jump(float jumpForce) {
            if (!_isJumping) {
                _animator.SetTrigger("jump");
                _rigidbody.velocity += new Vector2(0, jumpForce);
                _isJumping = true;
            }
        }

        public void Run(float speed) {
            _speed = speed;
        }

        private void FixedUpdate() {
            _rigidbody.velocity = new Vector2(_speed, _rigidbody.velocity.y);
        }

        [PostInject]
        private void Inject(IMovingController movingController) {
            movingController.Add(this);
            foreach (var stand in GetComponentsInChildren<Stand>()) {
                stand.Grounded += OnGrounded;
            }
        }

        protected override void Awake() {
            base.Awake();
            _animator = GetComponent<Animator>();
        }

        private void OnGrounded() {
            Debug.Log("ground");
            _isJumping = false;
            _animator.SetTrigger("run");
        }
    }
}