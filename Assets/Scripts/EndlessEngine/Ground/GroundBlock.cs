// Created 09.11.2015 
// Modified by Gorbach Alex 09.11.2015 at 10:42

namespace Assets.Scripts.EndlessEngine.Ground {
    #region References

    using UnityEngine;

    #endregion

    [RequireComponent(typeof(Collider2D))]
    internal class GroundBlock : SolidItem<GroundBlock>, IGroundBlock {
        [SerializeField]
        private BorderLevel _leftLevel;

        [SerializeField]
        private BorderLevel _rightLevel;

        protected override GroundBlock Instance {
            get {
                return this;
            }
        }

        public override bool IsCompatibleWith(GroundBlock other) {
            if (other == null) {
                return true;
            }
            return _rightLevel == other._leftLevel;
        }
    }
}