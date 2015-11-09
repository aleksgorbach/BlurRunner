// Created 04.11.2015
// Modified by Александр 08.11.2015 at 21:02

namespace Assets.Scripts.EndlessEngine.Decorations {
    #region References

    using Engine.Factory.Strategy;
    using Engine.Pool;
    using UnityEngine;

    #endregion

    internal class DecorationPool : GameObjectPool<DecorationItem> {
        [SerializeField]
        private DecorationsFactory _factory;

        [SerializeField]
        private DecorationStrategy _strategy;

        protected override Engine.Factory.IFactory<DecorationItem> Factory {
            get { return _factory; }
        }

        public override IChooseStrategy<DecorationItem> Strategy {
            get { return _strategy; }
        }
    }
}