// Created 28.10.2015
// Modified by Александр 02.11.2015 at 21:06

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
        public const string DEFAULT_STRATEGY_KEY = "defaultStrategy";


        [Inject(CAN_GROW_KEY)]
        private bool _canGrow;

        [Inject(DEFAULT_STRATEGY_KEY)]
        private IPoolStrategy<T> _defaultStrategy;

        [Inject]
        private Factory.IFactory<T> _factory;

        [Inject(INITIAL_SIZE_KEY)]
        private int _initialSize;

        protected List<Item> _pool;

        public T Get(IPoolStrategy<T> strategy) {
            T obj;
            try {
                obj = strategy.Get(_pool.Where(item => item.Free).Select(item => item.Object));
            }
            catch (ArgumentOutOfRangeException) {
                if (!_canGrow || (obj = AddNew(strategy)) == null) {
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
                AddNew(_defaultStrategy);
            }
        }

        private T AddNew(IPoolStrategy<T> strategy) {
            var obj = GetNew(strategy);
            if (obj == null) {
                return null;
            }
            obj.transform.SetParent(transform);
            obj.gameObject.SetActive(false);
            var item = new Item {Object = obj, Free = true};
            _pool.Add(item);
            return item.Object;
        }

        private T GetNew(IPoolStrategy<T> strategy) {
            return _factory.Create();
        }

        protected class Item {
            public T Object { get; set; }
            public bool Free { get; set; }
        }
    }
}