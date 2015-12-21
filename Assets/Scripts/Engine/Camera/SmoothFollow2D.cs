// Created 14.12.2015
// Modified by  21.12.2015 at 13:14

#region References

using UnityEngine;

#endregion

namespace Assets.Scripts.Engine.Camera {
    #region References

    using Zenject;
    using Camera = UnityEngine.Camera;

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

        // Update is called once per frame
        protected override void Update() {
            base.Update();
            if (_target) {
                var point = _camera.WorldToViewportPoint(_target.position);
                var delta = _target.position - _camera.ViewportToWorldPoint(new Vector3(0.3f, 0.5f, point.z));
                //(new Vector3(0.5, 0.5, point.z));
                var destination = transform.position + delta;
                var x = Vector3.SmoothDamp(transform.position, destination, ref _velocity, 0).x;
                transform.position = new Vector3(x, transform.position.y, transform.position.z);
            }
        }

        public void SetTarget(Transform target) {
            _target = target;
        }
    }
}