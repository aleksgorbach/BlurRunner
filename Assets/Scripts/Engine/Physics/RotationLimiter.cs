// Created 20.10.2015 
// Modified by Gorbach Alex 22.10.2015 at 15:31

namespace Assets.Scripts.Engine.Physics {
    #region References

    using UnityEngine;

    #endregion

    [RequireComponent(typeof(Rigidbody2D))]
    internal class RotationLimiter : MonoBehaviourBase {
        [SerializeField]
        private float _maxAngle;

        private Rigidbody2D _rigidbody;

        protected override void Awake() {
            base.Awake();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void LateUpdate() {
            _rigidbody.rotation = Mathf.Clamp(_rigidbody.rotation, -_maxAngle, _maxAngle);
        }
    }
}