// Created 20.10.2015 
// Modified by Gorbach Alex 22.10.2015 at 15:32

namespace Assets.Scripts.Engine.Pool {
    #region References

    using System.Collections.Generic;
    using System.Linq;
    using Extensions;
    using UnityEngine;
    using Zenject;

    #endregion

    internal abstract class GameObjectPool<T> : MonoBehaviourBase, IObjectPool<T>
        where T : MonoBehaviour {
        public const string INITIAL_SIZE_KEY = "initialSize";
        public const string CAN_GROW_KEY = "canGrow";

        private bool _canGrow;
        private List<Item> _pool;
        private Factory.IFactory<T> _factory;

        public T Get() {
            var free = _pool.Where(item => item.Free).Random();
            if (free != null) {
                free.Free = false;
                return free.Object;
            }
            if (_canGrow) {
                var created = AddNew();
                created.Free = false;
            }
            throw new PoolBusyException<T>();
        }

        public virtual void Release(T obj) {
            var item = _pool.First(x => x.Object.Equals(obj));
            item.Free = true;
            obj.transform.SetParent(transform);
            obj.gameObject.SetActive(false);
        }

        protected override void Awake() {
            base.Awake();
            _pool = new List<Item>();
        }

        [PostInject]
        protected void Init(
            [Inject(CAN_GROW_KEY)] bool canGrow,
            [Inject(INITIAL_SIZE_KEY)] int initialSize,
            Factory.IFactory<T> factory) {
            _canGrow = canGrow;
            _factory = factory;
            AddInitialItems(initialSize);
        }

        private void AddInitialItems(int count) {
            for (var i = 0; i < count; i++) {
                AddNew();
            }
        }

        private Item AddNew() {
            var obj = GetNew();
            obj.transform.SetParent(transform);
            obj.gameObject.SetActive(false);
            var item = new Item { Object = obj, Free = true };
            _pool.Add(item);
            return item;
        }

        private T GetNew() {
            return _factory.Create();
        }

        private class Item {
            public T Object { get; set; }
            public bool Free { get; set; }
        }
    }
}