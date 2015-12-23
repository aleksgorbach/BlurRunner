// Created 14.12.2015
// Modified by  23.12.2015 at 13:07

#region References

#endregion

namespace Assets.Scripts.Engine.Camera {
    #region References

    using UnityEngine;
    using Zenject;

    #endregion

    internal class SmoothFollow2D : MonoBehaviourBase {
        [Inject]
        private Camera _camera;

        [SerializeField]
        private Transform _target;

        private Vector3 _velocity = Vector3.zero;

        public Camera Camera {
            get { return _camera; }
        }

        protected void LateUpdate() {
            Update();
            if (_target) {
                var point = _camera.WorldToViewportPoint(_target.position);
                var delta = _target.position - _camera.ViewportToWorldPoint(new Vector3(0.3f, 0.5f, point.z));
                var destination = transform.position + delta;
                var x = Vector3.SmoothDamp(transform.position, destination, ref _velocity, 0f).x;
                transform.position = new Vector3(x, transform.position.y, transform.position.z);
            }
        }

        public void SetTarget(Transform target) {
            _target = target;
        }
    }
}