using System.Collections.Generic;
using Assets.Scripts.Engine.Extensions;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Engine.Factory {
    internal class RandomGameObjectFactory<T> : AbstractGameObjectFactory<T> where T : MonoBehaviour {
        private readonly ISettings _settings;

        public RandomGameObjectFactory(IInstantiator instantiator, ISettings settings) : base(instantiator) {
            _settings = settings;
        }

        protected override T PrefabToInstantiate {
            get { return _settings.Prefabs.Random(); }
        }

        public interface ISettings {
            IEnumerable<T> Prefabs { get; }
        }
    }
}