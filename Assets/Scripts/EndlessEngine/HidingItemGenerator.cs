// Created 30.10.2015 
// Modified by Gorbach Alex 04.11.2015 at 9:33

namespace Assets.Scripts.EndlessEngine {
    #region References

    using System.Collections.Generic;
    using System.Linq;
    using Engine;
    using Engine.Pool;
    using Interfaces;
    using Zenject;

    #endregion

    internal abstract class HidingItemGenerator<TItem> : MonoBehaviourBase
        where TItem : class, IHiding {
        protected List<TItem> _items;

        [Inject]
        private IObjectPool<TItem> _pool;

        protected override void Awake() {
            base.Awake();
            _items = new List<TItem>();
        }

        protected virtual void OnCreate(TItem item) {
        }

        protected TItem Create() {
            RemoveInvisibleItems();
            var block = _pool.Get();
            OnCreate(block);
            return block;
        }

        private void RemoveInvisibleItems() {
            var itemsToRemove = _items.Where(x => !x.IsVisible).ToList();
            foreach (var item in itemsToRemove) {
                Remove(item);
                OnRemove(item);
            }
        }

        protected void Remove(TItem item) {
            _items.Remove(item);
            _pool.Release(item);
        }

        protected virtual void OnRemove(TItem item) {
        }
    }
}