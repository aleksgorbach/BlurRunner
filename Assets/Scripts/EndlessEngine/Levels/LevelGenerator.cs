// Created 27.11.2015
// Modified by  27.11.2015 at 14:50

namespace Assets.Scripts.EndlessEngine.Levels {
    #region References

    using System;
    using Bonuses;
    using Decorations;
    using Endpoints;
    using Engine;
    using Gameplay.Bonuses;
    using Gameplay.Heroes;
    using Ground;
    using Obstacles;
    using State.Levels;
    using UnityEngine;

    #endregion

    internal class LevelGenerator : MonoBehaviourBase, ILevelGenerator {
        [SerializeField]
        private Bonuses _bonuses;

        [SerializeField]
        private Bonus[] _bonusesPrefabs;

        [SerializeField]
        private ObjectAnchor _cameraAnchor;

        [SerializeField]
        private Decorations _decorations;

        [SerializeField]
        private Ground _ground;

        private Hero _hero;

        [SerializeField]
        private HeroSpawner _heroSpawner;

        [SerializeField]
        private ObstacleGenerator _obstacles;

        public void Generate(ILevel level) {
            _ground.Generate(level.Length, level.Ground);
            _decorations.Generate(level.Length, level.Decorations);
            _obstacles.Generate(level.Length, level.Obstacles);
            _bonuses.Generate(level.Length, _bonusesPrefabs);

            _hero = _heroSpawner.Generate(level.Hero);
            _cameraAnchor.SetTarget(_hero.transform);
            OnGenerated();
        }

        public event Action Generated;

        private void OnGenerated() {
            var handler = Generated;
            if (handler != null) {
                handler();
            }
        }

        public void StartLevel() {
        }
    }
}