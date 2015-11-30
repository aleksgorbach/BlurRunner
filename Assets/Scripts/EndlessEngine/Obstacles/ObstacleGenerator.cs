// Created 20.11.2015
// Modified by  30.11.2015 at 13:52

namespace Assets.Scripts.EndlessEngine.Obstacles {
    #region References

    using Engine;
    using Engine.Factory;
    using Zenject;

    #endregion

    internal class ObstacleGenerator : RandomDistanceGenerator<Obstacle> {
        [Inject]
        private AbstractGameObjectFactory<Obstacle> _factory;

        [Inject]
        private IChooseStrategy<Obstacle> _strategy;


        protected override AbstractGameObjectFactory<Obstacle> Factory {
            get { return _factory; }
        }

        protected override IChooseStrategy<Obstacle> Strategy {
            get { return _strategy; }
        }
    }
}