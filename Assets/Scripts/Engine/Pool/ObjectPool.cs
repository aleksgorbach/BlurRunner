using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Engine.Pool {
    internal abstract class ObjectPool<T> : IObjectPool<T> {
        private readonly bool _canGrow;
        private readonly List<Item> _pool;

        protected ObjectPool(bool canGrow) {
            _pool = new List<Item>();
            _canGrow = canGrow;
        }

        public virtual T Get() {
            var free = _pool.FirstOrDefault(item => item.Free);
            if (free != null) {
                free.Free = false;
                return free.Object;
            }
            if (_canGrow) {
                var created = GetNew();
                _pool.Add(new Item {Object = created, Free = false});
            }
            throw new PoolBusyException<T>();
        }

        public virtual void Release(T obj) {
            var item = _pool.First(x => x.Object.Equals(obj));
            item.Free = true;
        }

        protected abstract T GetNew();

        private class Item {
            public T Object { get; set; }
            public bool Free { get; set; }
        }
    }
}