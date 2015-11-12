// Created 12.11.2015 
// Modified by Gorbach Alex 12.11.2015 at 10:33

namespace Assets.Scripts.UI.Popups.Factory {
    #region References

    using System;
    using System.Collections.Generic;
    using Engine.Factory.Strategy;
    using ModestTree;

    #endregion

    internal class PopupStrategy : RandomStrategy<Popup> {
        private Type _type;

        public void SetTarget<TPopup>() where TPopup : Popup {
            _type = typeof(TPopup);
        }

        protected override IEnumerable<Popup> Filter(IEnumerable<Popup> items) {
            if (_type == null) {
                return base.Filter(items);
            }
            return base.Filter(items).OfType(_type);
        }
    }
}