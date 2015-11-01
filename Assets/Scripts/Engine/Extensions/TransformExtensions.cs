// Created 28.10.2015
// Modified by Александр 01.11.2015 at 20:27

namespace Assets.Scripts.Engine.Extensions {
    #region References

    using UnityEngine;

    #endregion

    public static class TransformExtensions {
        public static void SetLocalZ(this Transform transform, float z) {
            var pos = transform.localPosition;
            transform.localPosition = new Vector3(pos.x, pos.y, z);
        }

        public static void SetLocalY(this Transform transform, float y) {
            var pos = transform.localPosition;
            transform.localPosition = new Vector3(pos.x, y, pos.z);
        }
    }
}