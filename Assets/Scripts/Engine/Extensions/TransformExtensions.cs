// Created 28.10.2015 
// Modified by Gorbach Alex 28.10.2015 at 16:18

namespace Assets.Scripts.Engine.Extensions {
    #region References

    using UnityEngine;

    #endregion

    public static class TransformExtensions {
        public static void SetLocalZ(this Transform transform, float z) {
            var pos = transform.localPosition;
            transform.localPosition = new Vector3(pos.x, pos.y, z);
        }
    }
}