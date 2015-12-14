// Created 14.12.2015
// Modified by  14.12.2015 at 10:57

namespace Assets.Scripts.Gameplay.Heroes.RunEngines {
    #region References

    using UnityEngine;

    #endregion

    internal class RigidbodyRunningEngine : HeroRunningEngine {
        [SerializeField]
        private Rigidbody2D _rigidbody;

        private float _speed;

        private void FixedUpdate() {
            _rigidbody.velocity = new Vector2(_speed, _rigidbody.velocity.y);
        }

        public override void Run(float speed) {
            _speed = speed;
        }

        public override bool Reached(float destination) {
            return _rigidbody.position.x >= destination;
        }
    }
}