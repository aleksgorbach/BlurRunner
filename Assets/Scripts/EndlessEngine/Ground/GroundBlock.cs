// Created 20.10.2015
// Modified by  30.11.2015 at 14:10

namespace Assets.Scripts.EndlessEngine.Ground {
    #region References

    using System.Linq;
    using Engine;
    using Engine.Pool;
    using UnityEngine;

    #endregion

    [RequireComponent(typeof (EdgeCollider2D))]
    internal class GroundBlock : MonoBehaviourBase, IGroundBlock, ICompatible<GroundBlock> {
        private const float DROP_MAX = 10;

        [SerializeField]
        private BorderLevel _leftLevel;

        [SerializeField]
        private BorderLevel _rightLevel;


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
            //return _leftLevel == other._rightLevel;
            return Mathf.Abs(LeftHeight - other.RightHeight) < DROP_MAX;
        }
    }
}