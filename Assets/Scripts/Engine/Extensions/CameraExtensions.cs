using UnityEngine;

namespace Assets.Scripts.Engine.Extensions {
    internal static class CameraExtensions {
        public static float GetWidth(this Camera camera, float targetPosition) {
            var distance = targetPosition - camera.transform.position.z;
            return camera.aspect*2.0f*distance*Mathf.Tan(camera.fieldOfView*0.5f*Mathf.Deg2Rad);
        }
    }
}