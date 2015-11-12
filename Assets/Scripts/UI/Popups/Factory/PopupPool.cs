// Created 23.10.2015 
// Modified by Gorbach Alex 12.11.2015 at 11:25

namespace Assets.Scripts.UI.Popups.Factory {
    #region References

    using Engine.Factory.Strategy;
    using Engine.Pool;
    using UnityEngine;

    #endregion

    internal class PopupPool : GameObjectPool<Popup> {
        [SerializeField]
        private PopupFactory _factory;

        [SerializeField]
        private PopupStrategy _strategy;

        protected override Engine.Factory.IFactory<Popup> Factory {
            get {
                return _factory;
            }
        }

        public override IChooseStrategy<Popup> Strategy {
            get {
                return _strategy;
            }
        }
    }
}