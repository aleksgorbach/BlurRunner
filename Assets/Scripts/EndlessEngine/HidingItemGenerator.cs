// Created 07.11.2015
// Modified by Александр 19.11.2015 at 20:55

namespace Assets.Scripts.EndlessEngine {
    #region References

    using System.Collections.Generic;
    using System.Linq;
    using Engine.Pool;

    #endregion

    internal abstract class HidingItemGenerator<TItem> : AbstractGenerator
        where TItem : HidingItem<TItem> {
        protected List<Item> _items;

        protected abstract GameObjectPool<TItem> Pool { get; }

        protected override void Awake() {
            base.Awake();
            _items = new List<Item>();
        }

        protected void Add(TItem item) {
            item.NeedRemove += Remove;
            var layer = item.transform.localPosition.z/100;
            _items.Add(new Item(item, layer));
        }

        protected TItem Create() {
            var block = Pool.Get();
            return block;
        }

        protected void Remove(TItem item) {
            var itemToRemove = _items.FirstOrDefault(x => x.Obj == (TItem) item);
            _items.Remove(itemToRemove);
            item.NeedRemove -= Remove;
            OnRemove(item);
            Pool.Release(item);
        }

        protected virtual void OnRemove(TItem item) {
        }

        protected class Item {
            public Item(TItem item, float layer) {
                Obj = item;
                Layer = layer;
            }

            public TItem Obj { get; private set; }
            public float Layer { get; private set; }
        }
    }
}