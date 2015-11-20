// Created 20.11.2015
// Modified by  20.11.2015 at 13:43

namespace Assets.Scripts.EndlessEngine.Obstacles {
    #region References

    using Engine.Factory;
    using Engine.Factory.Strategy;
    using Engine.Pool;
    using UnityEngine;

    #endregion

    internal class ObstaclePool : GameObjectPool<Obstacle> {
        [SerializeField]
        private ObstacleFactory _factory;

        [SerializeField]
        private ObstacleStrategy _strategy;

        protected override IFactory<Obstacle> Factory {
            get { return _factory; }
        }

        public override IChooseStrategy<Obstacle> Strategy {
            get { return _strategy; }
        }
    }
}