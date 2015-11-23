// Created 20.11.2015
// Modified by  23.11.2015 at 13:13

namespace Assets.Scripts.EndlessEngine.Obstacles {
    #region References

    using System.Collections.Generic;
    using Engine.Factory;
    using Engine.Factory.Strategy;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class ObstacleFactory : MultipleGameObjectFactory<Obstacle> {
        [Inject]
        private Obstacle[] _prefabs;

        [SerializeField]
        private ObstacleStrategy _strategy;

        protected override ChooseStrategy<Obstacle> Strategy {
            get { return _strategy; }
        }

        protected override IEnumerable<Obstacle> Items {
            get { return _prefabs; }
        }

        protected override void Start() {
            base.Start();
            OnLoaded();
        }
    }
}