// Created 30.11.2015
// Modified by Александр 30.11.2015 at 21:53

namespace Assets.Scripts.EndlessEngine.Ground {
    #region References

    using System.Linq;
    using Engine;
    using Engine.Pool;
    using UnityEngine;

    #endregion

    [RequireComponent(typeof (EdgeCollider2D))]
    internal class GroundBlock : MonoBehaviourBase, IGroundBlock, ICompatible<GroundBlock> {
        /// <summary>
        /// Max offset between blocks edges that keeps compatibility
        /// </summary>
        private const float DROP_MAX = 10;

        public float Length {
            get { return rectTransform.sizeDelta.x; }
        }

        private float LeftHeight {
            get {
                var col = GetComponent<EdgeCollider2D>();
                return col.points.OrderBy(point => point.x).First().y;
            }
        }

        private float RightHeight {
            get {
                var col = GetComponent<EdgeCollider2D>();
                return col.points.OrderBy(point => point.x).Last().y;
            }
        }

        public bool IsCompatibleWith(GroundBlock other) {
            if (other == null) {
                return true;
            }
            return Mathf.Abs(LeftHeight - other.RightHeight) < DROP_MAX;
        }
    }
}