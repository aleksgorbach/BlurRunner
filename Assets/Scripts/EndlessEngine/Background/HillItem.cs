// Created 09.11.2015 
// Modified by Gorbach Alex 09.11.2015 at 10:50

namespace Assets.Scripts.EndlessEngine.Background {
    #region References

    using Ground;
    using UnityEngine;

    #endregion

    internal class HillItem : SolidItem<HillItem> {
        [SerializeField]
        private BorderLevel _leftLevel;

        [SerializeField]
        private BorderLevel _rightLevel;

        protected override HillItem Instance {
            get {
                return this;
            }
        }

        public override bool IsCompatibleWith(HillItem other) {
            if (other == null) {
                return true;
            }
            return _rightLevel == other._leftLevel;
        }
    }
}