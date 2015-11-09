// Created 07.11.2015
// Modified by Александр 08.11.2015 at 20:52

namespace Assets.Scripts.Engine.Pool {
    #region References

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Factory.Strategy;
    using UnityEngine;
    using Zenject;

    #endregion

    internal abstract class GameObjectPool<T> : MonoBehaviourBase, IObjectPool<T>
        where T : MonoBehaviour {
        [SerializeField]
        private int _initialSize;

        protected List<Item> _pool;

        protected abstract Factory.IFactory<T> Factory { get; }

        public abstract IChooseStrategy<T> Strategy { get; }

        public T Get() {
            T obj;
            try {
                obj = Strategy.Get(_pool.Where(item => item.Free).Select(item => item.Object));
                if (obj == null) {
                    throw new PoolBusyException<T>();
                }
            }
            catch (Exception) {
                obj = AddNew();
                if (obj == null) {
                    throw new PoolBusyException<T>();
                }
            }
            var entry = _pool.First(x => x.Object == obj);
            entry.Free = false;
            return obj;
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
        private void PostInject() {
            AddInitialItems(_initialSize);
        }

        private void AddInitialItems(int count) {
            for (var i = 0; i < count; i++) {
                AddNew();
            }
        }

        private T AddNew() {
            var obj = GetNew();
            if (obj == null) {
                return null;
            }
            obj.transform.SetParent(transform);
            obj.gameObject.SetActive(false);
            var item = new Item {Object = obj, Free = true};
            _pool.Add(item);
            return item.Object;
        }

        private T GetNew() {
            return Factory.Create();
        }

        protected class Item {
            public T Object { get; set; }
            public bool Free { get; set; }
        }
    }
}