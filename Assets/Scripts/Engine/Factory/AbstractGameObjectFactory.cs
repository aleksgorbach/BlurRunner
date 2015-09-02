using UnityEngine;
using Zenject;

namespace Assets.Scripts.Engine.Factory {
    internal abstract class AbstractGameObjectFactory<T> : IFactory<T> where T : MonoBehaviour {
        private readonly IInstantiator _instantiator;

        protected AbstractGameObjectFactory(IInstantiator instantiator) {
            _instantiator = instantiator;
        }

        protected abstract T PrefabToInstantiate { get; }

        private static int index = 0;

        public T Create() {
            var created = _instantiator.InstantiatePrefab(PrefabToInstantiate.gameObject).GetComponent<T>();
            created.name = string.Format("{0} [{1}]", created.name, index++);
            return created;
        }
    }
}