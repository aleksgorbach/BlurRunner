// Created 30.11.2015
// Modified by  30.11.2015 at 11:01

namespace Assets.Scripts.UI.Popups.Factory {
    #region References

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Engine.Factory;
    using ModestTree;

    #endregion

    internal class PopupStrategy : IChooseStrategy<Popup> {
        private Type _type;

        public Popup Choose(IEnumerable<Popup> items) {
            return items.OfType(_type).First();
        }

        public void SetType<T>() where T : Popup {
            _type = typeof (T);
        }
    }
}