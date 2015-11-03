// Created 03.11.2015 
// Modified by Gorbach Alex 03.11.2015 at 15:10

namespace Assets.Scripts.Purchases.Storage {
    #region References

    using System.Collections;
    using System.Collections.Generic;

    #endregion

    internal class InAppStorage : IInAppStorage {
        private readonly List<IInAppItem> _items;

        public InAppStorage(List<IInAppItem> items) {
            _items = items;
        }

        public IEnumerator<IInAppItem> GetEnumerator() {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}