// Created 20.10.2015 
// Modified by Gorbach Alex 04.11.2015 at 13:34

#region References

using System.Collections.Generic;
using UnityEngine;
using Zenject;

#endregion

namespace Assets.Scripts.Engine.Factory {
    internal class MultipleGameObjectFactory<T> : AbstractGameObjectFactory<T>
        where T : MonoBehaviour {
        private readonly ISettings _settings;

        protected MultipleGameObjectFactory(IInstantiator instantiator, ISettings settings)
            : base(instantiator) {
            _settings = settings;
        }

        protected override IEnumerable<T> Items {
            get {
                return _settings.Prefabs;
            }
        }

        public interface ISettings {
            IEnumerable<T> Prefabs { get; }
        }
    }
}