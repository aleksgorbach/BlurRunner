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

        [SerializeField]
        private Vector2 _viewportPosition;

        private Vector3 _velocity = Vector3.zero;
        private Vector3 _targetPos;
        private float interpVelocity = 20f;
        private Vector3 offset = new Vector2(30, 10);


        public Camera Camera {
            get { return _camera; }
        }

        //protected void LateUpdate() {
        //    Update();
        //    if (_target) {
        //        var point = _camera.WorldToViewportPoint(_target.position);
        //        var delta = _target.position - _camera.ViewportToWorldPoint(new Vector3(0.25f, 0.3f, point.z));
        //        if (delta.magnitude < 20) {
        //            return;
        //        }
        //        Vector2 destination = transform.position + delta;
        //        var pos = Vector3.SmoothDamp(transform.position, destination, ref _velocity, 0.0f);
        //        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
        //    }
        //}
        private void FixedUpdate() {
            if (_target) {
                var posNoZ = transform.position;
                posNoZ.z = _target.transform.position.z;

                var targetDirection = (_target.transform.position - posNoZ);

                interpVelocity = targetDirection.magnitude*5f;

                _targetPos = transform.position + (targetDirection.normalized*interpVelocity*Time.deltaTime);

                transform.position = Vector3.Lerp(transform.position, _targetPos + offset, 0.8f);
            }
        }

        public void SetTarget(Transform target) {
            _target = target;
            transform.position = new Vector3(_target.position.x, _target.position.y, transform.position.z);
        }
    }
}