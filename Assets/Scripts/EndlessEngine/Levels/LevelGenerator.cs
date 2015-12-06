// Created 30.11.2015
// Modified by Александр 06.12.2015 at 18:38

namespace Assets.Scripts.EndlessEngine.Levels {
    #region References

    using Bonuses;
    using Decorations;
    using Endpoints;
    using Engine;
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


        public Hero Generate(ILevel level) {
            _ground.Generate(level.Length, level.Ground);
            _decorations.Generate(level.Length, level.Decorations, level.Hills);
            _obstacles.Generate(level.Length, level.Obstacles);
            _bonuses.Generate(level.Length, level.Bonuses);

            _hero = _heroSpawner.Generate(level.Hero);
            _hero.Destination = level.Length*.95f;
            _cameraAnchor.SetTarget(_hero.transform);
            return _hero;
        }
    }
}