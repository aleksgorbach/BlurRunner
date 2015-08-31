using UnityEngine;
using Zenject;

namespace Assets.Scripts.Engine.Factory {
    internal class GameObjectFactory<T> : AbstractGameObjectFactory<T> where T : MonoBehaviour {
        private readonly T _prefab;

        public GameObjectFactory(IInstantiator instantiator, T prefab) : base(instantiator) {
            _prefab = prefab;
        }

        protected override T PrefabToInstantiate {
            get { return _prefab; }
        }
    }
}