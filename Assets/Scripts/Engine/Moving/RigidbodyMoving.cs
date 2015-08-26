using UnityEngine;

namespace Assets.Scripts.Engine.Moving {
    [RequireComponent(typeof(Rigidbody2D))]
    class RigidbodyMoving : HeroMovingController {
        private Rigidbody2D _rigidbody;
        protected override void Awake() {
            base.Awake();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        protected override void Run() {
            _rigidbody.velocity = _runVector;
        }

        protected override void Jump() {
            _rigidbody.velocity = _jumpVector;
        }
    }
}
