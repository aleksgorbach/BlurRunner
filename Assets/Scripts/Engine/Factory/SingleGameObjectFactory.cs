// Created 04.11.2015
// Modified by Александр 08.11.2015 at 18:15

namespace Assets.Scripts.Engine.Factory {
    #region References

    using System.Collections.Generic;
    using UnityEngine;
    using Zenject;

    #endregion

    internal abstract class SingleGameObjectFactory<T> : AbstractGameObjectFactory<T>
        where T : MonoBehaviour {
        [Inject]
        private T _prefab;

        protected override IEnumerable<T> Items {
            get { return new[] {_prefab}; }
        }
    }
}