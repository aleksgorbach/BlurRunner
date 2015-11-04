// Created 20.10.2015 
// Modified by Gorbach Alex 04.11.2015 at 13:29

#region References

using UnityEngine;
using Zenject;

#endregion

namespace Assets.Scripts.Engine.Factory {
    #region References

    using System.Collections.Generic;
    using Strategy;

    #endregion

    internal abstract class AbstractGameObjectFactory<T> : IFactory<T>
        where T : MonoBehaviour {
        private static int index = 0;
        private readonly IInstantiator _instantiator;

        protected AbstractGameObjectFactory(IInstantiator instantiator) {
            _instantiator = instantiator;
        }

        public IChooseStrategy<T> Strategy { set; private get; }

        //private T PrefabToInstantiate { get; }
        protected abstract IEnumerable<T> Items { get; }

        public virtual T Create() {
            var prefab = Strategy.Get(Items); //PrefabToInstantiate;
            if (prefab == null) {
                return null;
            }
            var created = _instantiator.InstantiatePrefab(prefab.gameObject).GetComponent<T>();
            created.name = string.Format("{0} [{1}]", created.name, index++);
            return created;
        }
    }
}