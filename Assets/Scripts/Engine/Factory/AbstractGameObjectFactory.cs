// Created 04.11.2015
// Modified by Александр 08.11.2015 at 20:53

#region References

#endregion

namespace Assets.Scripts.Engine.Factory {
    #region References

    using System.Collections.Generic;
    using Strategy;
    using UnityEngine;
    using Zenject;

    #endregion

    internal abstract class AbstractGameObjectFactory<T> : MonoBehaviourBase, IFactory<T>
        where T : MonoBehaviour {
        private static int index = 0;

        [Inject]
        private IInstantiator _instantiator;

        protected abstract ChooseStrategy<T> Strategy { get; }

        protected abstract IEnumerable<T> Items { get; }

        public virtual T Create() {
            var prefab = Strategy.Get(Items); //PrefabToInstantiate;
            if (prefab == null) {
                return null;
            }
            var created = Instantiate(prefab.gameObject).GetComponent<T>();
            created.name = string.Format("{0} [{1}]", created.name, index++);
            return created;
        }
    }
}