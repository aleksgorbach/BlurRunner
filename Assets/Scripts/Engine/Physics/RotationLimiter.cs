using UnityEngine;

namespace Assets.Scripts.Engine.Physics {
    [RequireComponent(typeof (Rigidbody2D))]
    internal class RotationLimiter : MonoBehaviour {
        [SerializeField] private float _maxAngle;
        private Rigidbody2D _rigidbody;

        private void Awake() {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void LateUpdate() {
            _rigidbody.rotation = Mathf.Clamp(_rigidbody.rotation, -_maxAngle, _maxAngle);
        }
    }
}