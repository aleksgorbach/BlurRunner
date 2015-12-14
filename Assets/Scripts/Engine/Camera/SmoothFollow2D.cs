// Created 14.12.2015
// Modified by  14.12.2015 at 13:05

#region References

using UnityEngine;

#endregion

namespace Assets.Scripts.Engine.Camera {
    #region References

    using Zenject;
    using Camera = UnityEngine.Camera;

    #endregion

    public class SmoothFollow2D : MonoBehaviour {
        [Inject]
        private Camera _camera;

        [SerializeField]
        private Transform _target;

        private Vector3 _velocity = Vector3.zero;

        // Update is called once per frame
        private void Update() {
            if (_target) {
                var point = _camera.WorldToViewportPoint(_target.position);
                var delta = _target.position - _camera.ViewportToWorldPoint(new Vector3(0.2f, 0.5f, point.z));
                //(new Vector3(0.5, 0.5, point.z));
                var destination = transform.position + delta;
                transform.position = Vector3.SmoothDamp(transform.position, destination, ref _velocity, 0);
            }
        }

        public void SetTarget(Transform target) {
            _target = target;
        }
    }
}