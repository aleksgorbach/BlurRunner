// Created 20.10.2015
// Modified by  27.11.2015 at 12:52

namespace Assets.Scripts.EndlessEngine.Ground {
    #region References

    using Engine;
    using Engine.Pool;
    using UnityEngine;

    #endregion

    [RequireComponent(typeof (Collider2D))]
    internal class GroundBlock : MonoBehaviourBase, IGroundBlock, ICompatible<GroundBlock> {
        [SerializeField]
        private BorderLevel _leftLevel;

        [SerializeField]
        private BorderLevel _rightLevel;


        public virtual float Length {
            get { return rectTransform.sizeDelta.x; }
        }

        public bool IsCompatibleWith(GroundBlock other) {
            if (other == null) {
                return true;
            }
            return _leftLevel == other._rightLevel;
        }
    }
}