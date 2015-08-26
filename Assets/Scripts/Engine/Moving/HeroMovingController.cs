using UnityEngine;

namespace Assets.Scripts.Engine.Moving {
    internal abstract class HeroMovingController : MonoBehaviour {
        [SerializeField]
        private float _jumpForce;

        [SerializeField]
        private float _speed;

        protected Vector2 _runVector;
        protected Vector2 _jumpVector;

        protected virtual void Awake() {
            _runVector = Vector2.right * _speed;
            _jumpVector = Vector2.up * _jumpForce;
        }

        private void Update() {
            Run();
            if (Input.GetKeyDown("space")) {
                Jump();
            }
        }

        protected abstract void Run();
        protected abstract void Jump();
    }
}