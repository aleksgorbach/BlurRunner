// Created 20.10.2015 
// Modified by Gorbach Alex 06.11.2015 at 11:30

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
        public const string INITIAL_SIZE_KEY = "initialSize";
        public const string CAN_GROW_KEY = "canGrow";

        protected List<Item> _pool;

        [Inject(CAN_GROW_KEY)]
        private bool _canGrow;

        [Inject]
        private Factory.IFactory<T> _factory;

        [Inject(INITIAL_SIZE_KEY)]
        private int _initialSize;

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
                if (_canGrow) {
                    obj = AddNew();
                    if (obj == null) {
                        throw new PoolBusyException<T>();
                    }
                }
                else {
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
            _factory.Strategy = Strategy;
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
            var item = new Item { Object = obj, Free = true };
            _pool.Add(item);
            return item.Object;
        }

        private T GetNew() {
            // todo фабрика должна создавать блок, исходя из стратегии
            return _factory.Create();
        }

        protected class Item {
            public T Object { get; set; }
            public bool Free { get; set; }
        }
    }
}