// Created 19.11.2015
// Modified by Александр 19.11.2015 at 19:53

#region References

#endregion

namespace Assets.Scripts.Engine.Utils {
    #region References

    using UnityEngine;
    using Zenject;

    #endregion

    /// <summary>
    /// Parallax scrolling script that should be assigned to a layer
    /// </summary>
    internal class BackgroundParallax : MonoBehaviourBase {
        [Inject]
        private Camera _camera;

        private float _cameraPrevPos;

        [SerializeField]
        private bool _linearParallax;

        [SerializeField]
        private float _speed;

        [PostInject]
        private void Inject() {
            _cameraPrevPos = _camera.transform.position.x;
        }

        private void FixedUpdate() {
            var cameraPos = _camera.transform.position.x;
            var delta = cameraPos - _cameraPrevPos;
            _cameraPrevPos = cameraPos;
            foreach (var child in transform) {
                var item = child as Transform;
                var layer = _linearParallax ? _speed : item.localPosition.z/150*delta;
                item.Translate(-layer, 0, 0);
            }
        }
    }
}