// Created 30.11.2015
// Modified by  30.11.2015 at 13:52

namespace Assets.Scripts.EndlessEngine.Decorations {
    #region References

    using Engine;
    using Engine.Factory;
    using Zenject;

    #endregion

    internal class DecorationLayer : RandomDistanceGenerator<Decoration> {
        [Inject]
        private AbstractGameObjectFactory<Decoration> _factory;

        [Inject]
        private IChooseStrategy<Decoration> _strategy;

        protected override AbstractGameObjectFactory<Decoration> Factory {
            get { return _factory; }
        }

        protected override IChooseStrategy<Decoration> Strategy {
            get { return _strategy; }
        }
    }
}