using UnityEngine;

namespace Assets.Scripts.Engine.Moving {
    internal class MovingController : MonoBehaviour {
        [SerializeField] private int _jumpForce;
        private Vector2 _jumpVector;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private int _runForce;
        private Vector2 _runVector;

        private void Awake() {
            _runVector = Vector2.right*_runForce;
            _jumpVector = Vector2.up*_jumpForce;
        }

        public void Run() {
            _rigidbody.velocity = _runVector;
        }

        public void Jump() {
            _rigidbody.AddForce(_jumpVector);
        }
    }
}