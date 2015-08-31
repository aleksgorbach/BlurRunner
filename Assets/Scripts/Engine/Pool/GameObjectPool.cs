using Assets.Scripts.Engine.Factory;
using UnityEngine;

namespace Assets.Scripts.Engine.Pool {
    internal abstract class GameObjectPool<T> : ObjectPool<T> where T : MonoBehaviour {
        private readonly IFactory<T> _factory;

        protected GameObjectPool(bool canGrow, IFactory<T> factory) : base(canGrow) {
            _factory = factory;
        }

        protected override T GetNew() {
            return _factory.Create();
        }
    }
}