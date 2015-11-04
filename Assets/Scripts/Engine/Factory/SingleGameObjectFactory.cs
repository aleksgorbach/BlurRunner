// Created 20.10.2015 
// Modified by Gorbach Alex 04.11.2015 at 13:24

#region References

using UnityEngine;
using Zenject;

#endregion

namespace Assets.Scripts.Engine.Factory {
    #region References

    using System.Collections.Generic;

    #endregion

    internal class SingleGameObjectFactory<T> : AbstractGameObjectFactory<T>
        where T : MonoBehaviour {
        private readonly T _prefab;

        public SingleGameObjectFactory(IInstantiator instantiator, T prefab)
            : base(instantiator) {
            _prefab = prefab;
        }

        protected override IEnumerable<T> Items {
            get {
                return new[] { _prefab };
            }
        }
    }
}