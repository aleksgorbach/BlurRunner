using UnityEngine;
using Zenject;

namespace Assets.Scripts.Engine.Factory {
    internal abstract class AbstractGameObjectFactory<T> : IFactory<T> where T : MonoBehaviour {
        private readonly IInstantiator _instantiator;

        protected AbstractGameObjectFactory(IInstantiator instantiator) {
            _instantiator = instantiator;
        }

        protected abstract T PrefabToInstantiate { get; }

        public T Create() {
            return _instantiator.InstantiatePrefab(PrefabToInstantiate.gameObject).GetComponent<T>();
        }
    }
}