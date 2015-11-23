// Created 20.10.2015
// Modified by  23.11.2015 at 12:56

#region References

#endregion

namespace Assets.Scripts.Engine.Factory {
    #region References

    using System;
    using System.Collections.Generic;
    using Strategy;
    using UnityEngine;
    using Zenject;

    #endregion

    internal abstract class AbstractGameObjectFactory<T> : MonoBehaviourBase, IFactory<T>
        where T : MonoBehaviour {
        private static int index = 0;

        protected abstract ChooseStrategy<T> Strategy { get; }

        protected abstract IEnumerable<T> Items { get; }

        public virtual T Create(IInstantiator instantiator) {
            var prefab = Strategy.Get(Items); //PrefabToInstantiate;
            if (prefab == null) {
                return null;
            }
            var created = instantiator.InstantiatePrefabForComponent<T>(prefab.gameObject);
            created.name = string.Format("{0} [{1}]", created.name, index++);
            return created;
        }

        public event Action Loaded;

        protected void OnLoaded() {
            var handler = Loaded;
            if (handler != null) {
                handler();
            }
        }
    }
}