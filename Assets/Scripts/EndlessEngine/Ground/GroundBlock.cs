// Created 04.11.2015
// Modified by Александр 26.11.2015 at 21:24

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


        public float Length {
            get { return 256; }
        }

        public bool IsCompatibleWith(GroundBlock other) {
            if (other == null) {
                return true;
            }
            return _leftLevel == other._rightLevel;
        }
    }
}