// Created 20.10.2015
// Modified by  20.11.2015 at 9:14

namespace Assets.Scripts.Engine.Physics {
    #region References

    using UnityEngine;

    #endregion

    [RequireComponent(typeof (Rigidbody2D))]
    internal class RotationLimiter : MonoBehaviourBase {
        [SerializeField]
        private float _maxAngle;

        private Rigidbody2D _rigidbody;

        protected override void Awake() {
            base.Awake();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate() {
            //_rigidbody.rotation = Mathf.Clamp(_rigidbody.rotation, -_maxAngle, _maxAngle);
            if (_rigidbody.rotation > _maxAngle || _rigidbody.rotation < -_maxAngle) {
                _rigidbody.angularDrag = 0;
            }
        }
    }
}