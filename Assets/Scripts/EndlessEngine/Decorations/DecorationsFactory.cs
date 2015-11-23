// Created 10.11.2015
// Modified by  23.11.2015 at 12:57

namespace Assets.Scripts.EndlessEngine.Decorations {
    #region References

    using System.Collections.Generic;
    using Engine.Factory;
    using Engine.Factory.Strategy;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class DecorationsFactory : MultipleGameObjectFactory<DecorationItem> {
        [Inject]
        private DecorationItem[] _prefabs;

        [SerializeField]
        private DecorationStrategy _strategy;

        protected override ChooseStrategy<DecorationItem> Strategy {
            get { return _strategy; }
        }

        protected override IEnumerable<DecorationItem> Items {
            get { return _prefabs; }
        }

        [PostInject]
        private void Inject() {
            OnLoaded();
        }
    }
}