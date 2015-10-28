// Created 20.10.2015 
// Modified by Gorbach Alex 28.10.2015 at 13:01

#region References

using UnityEngine;
using Zenject;

#endregion

namespace Assets.Scripts.Engine.Factory {
    internal abstract class AbstractGameObjectFactory<T> : IFactory<T>
        where T : MonoBehaviour {
        private static int index = 0;
        private readonly IInstantiator _instantiator;

        protected AbstractGameObjectFactory(IInstantiator instantiator) {
            _instantiator = instantiator;
        }

        protected abstract T PrefabToInstantiate { get; }

        public T Create() {
            var prefab = PrefabToInstantiate;
            if (prefab == null) {
                return null;
            }
            var created = _instantiator.InstantiatePrefab(prefab.gameObject).GetComponent<T>();
            created.name = string.Format("{0} [{1}]", created.name, index++);
            return created;
        }
    }
}