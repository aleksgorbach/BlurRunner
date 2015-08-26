using UnityEngine;

namespace Assets.Scripts.Engine.Moving {

    [RequireComponent(typeof(Rigidbody2D))]
    internal class KeyboardMoving : MonoBehaviour {

        [SerializeField]
        private float _jumpForce;

        private Rigidbody2D _rigidbody;

        private void Awake() {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Space)) {
                Jump();
            }
        }

        private void Jump() {
            _rigidbody.AddForce(new Vector2(0, _jumpForce));
        }
    }
}