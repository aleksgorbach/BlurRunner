// Created 15.01.2016
// Modified by  15.01.2016 at 8:55

namespace Assets.Scripts.EndlessEngine.Actions {
    #region References

    using UnityEngine;

    #endregion

    [RequireComponent(typeof (Camera))]
    internal class LevelStartCameraAction : CameraAction {
        [SerializeField]
        private float _duration;

        private Camera _camera;

        protected override void Awake() {
            base.Awake();
            _camera = GetComponent<Camera>();
        }

        protected override void Start() {
            base.Start();
            Action.Invoke();
        }

        protected override Camera Camera {
            get { return _camera; }
        }

        protected override float MovingDuration {
            get { return _duration; }
        }
    }
}