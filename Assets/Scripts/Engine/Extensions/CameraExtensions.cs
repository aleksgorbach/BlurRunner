// Created 20.10.2015
// Modified by  14.12.2015 at 13:04

#region References

using UnityEngine;

#endregion

namespace Assets.Scripts.Engine.Extensions {
    #region References

    using Camera = UnityEngine.Camera;

    #endregion

    internal static class CameraExtensions {
        public static float GetWidth(this Camera camera, float targetPosition) {
            var distance = targetPosition - camera.transform.position.z;
            return camera.aspect*2.0f*distance*Mathf.Tan(camera.fieldOfView*0.5f*Mathf.Deg2Rad);
        }
    }
}