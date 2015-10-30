// Created 30.10.2015 
// Modified by Gorbach Alex 30.10.2015 at 15:00

namespace Assets.Scripts.EndlessEngine {
    #region References

    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Engine;

    #endregion

    internal abstract class HidingItemGenerator<TItem> : MonoBehaviourBase
        where TItem : IHiding {
        protected List<TItem> _items;

        protected override void Awake() {
            base.Awake();
            _items = new List<TItem>();
        }

        public virtual void Add(TItem item) {
            RemoveInvisibleItems();
        }

        //protected virtual void FixedUpdate() {
        //    if (_items.Count == 0) {
        //        return;
        //    }
        //    var item = _items[0];
        //    while (!item.IsVisible) {
        //        Remove(item);
        //        if (_items.Count == 0) {
        //            break;
        //        }
        //        item = _items[0];
        //    }
        //    CheckForMissingItems();
        //}

        private void RemoveInvisibleItems() {
            var itemsToRemove = _items.Where(x => !x.IsVisible).ToList();
            foreach (var item in itemsToRemove) {
                OnItemHide(item);
            }
        }

        protected abstract void OnItemHide(TItem item);

        protected virtual void CheckForMissingItems() {
        }
    }
}