using UnityEngine;

namespace Assets.Scripts.Gameplay.Heroes {
    internal class Hero : MonoBehaviour {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;

        private void Update() {
            if (Input.GetKey(KeyCode.Space)) {
                _rigidbody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Force);
            }
            _rigidbody.velocity = new Vector2(_speed, 0);
        }
    }
}