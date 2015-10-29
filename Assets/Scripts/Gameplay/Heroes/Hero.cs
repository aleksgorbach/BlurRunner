// Created 22.10.2015
// Modified by Александр 29.10.2015 at 21:22

namespace Assets.Scripts.Gameplay.Heroes {
    #region References

    using Engine;
    using Engine.Moving;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class Hero : MonoBehaviourBase, IMovable {
        private bool _isJumping;

        [SerializeField]
        private Rigidbody2D _rigidbody;

        private float _speed;

        private Stand[] _stands;

        public Vector2 Velocity {
            get { return _rigidbody.velocity; }
            set { _rigidbody.velocity = value; }
        }

        public void Jump(float jumpForce) {
            if (!_isJumping) {
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
                stand.Grounded += () => _isJumping = false;
            }
        }
    }
}