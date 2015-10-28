// Created 20.10.2015 
// Modified by Gorbach Alex 28.10.2015 at 14:04

#region References

using System.Collections.Generic;
using Assets.Scripts.Engine.Extensions;
using UnityEngine;
using Zenject;

#endregion

namespace Assets.Scripts.Engine.Factory {
    internal class RandomGameObjectFactory<T> : AbstractGameObjectFactory<T>
        where T : MonoBehaviour {
        private readonly ISettings _settings;

        public RandomGameObjectFactory(IInstantiator instantiator, ISettings settings)
            : base(instantiator) {
            _settings = settings;
        }

        protected override T PrefabToInstantiate {
            get {
                return _settings.Prefabs.Random();
            }
        }

        public interface ISettings {
            IEnumerable<T> Prefabs { get; }
        }
    }
}