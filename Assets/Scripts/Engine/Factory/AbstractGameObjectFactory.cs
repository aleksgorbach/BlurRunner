// Created 20.10.2015
// Modified by  30.11.2015 at 9:03

#region References

#endregion

namespace Assets.Scripts.Engine.Factory {
    #region References

    using UnityEngine;
    using Zenject;

    #endregion

    internal abstract class AbstractGameObjectFactory<T> : IFactory<T>
        where T : MonoBehaviour {
        private IChooseStrategy<T> _strategy;

        [Inject]
        protected IInstantiator Container;

        protected T[] Prefabs;

        public void Init(T[] prefabs, IChooseStrategy<T> strategy) {
            Prefabs = prefabs;
            _strategy = strategy;
        }

        public T Create() {
            return Container.InstantiatePrefabForComponent<T>(_strategy.Choose(Prefabs).gameObject);
        }
    }
}