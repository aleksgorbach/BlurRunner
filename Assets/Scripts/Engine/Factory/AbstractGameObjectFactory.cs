// Created 20.10.2015
// Modified by  27.11.2015 at 12:19

#region References

#endregion

namespace Assets.Scripts.Engine.Factory {
    #region References

    using UnityEngine;
    using Zenject;

    #endregion

    internal abstract class AbstractGameObjectFactory<T> : IFactory<T>
        where T : MonoBehaviour {
        [Inject]
        protected IInstantiator Container;

        protected T[] Prefabs;

        public void Init(T[] prefabs) {
            Prefabs = prefabs;
        }
    }
}