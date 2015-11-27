// Created 20.11.2015
// Modified by  27.11.2015 at 10:52

namespace Assets.Scripts.EndlessEngine.Obstacles {
    #region References

    using Engine;
    using Strategy;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class ObstacleGenerator : AbstractGenerator<Obstacle> {
        [Inject]
        private ObstacleFactory _factory;

        [SerializeField]
        private AbstractStrategy _strategy;

        public override void Generate(float length, Obstacle[] prefabs) {
            _factory.Init(prefabs);
            var currentPos = _strategy.DistanceToGenerate;
            while (currentPos < length) {
                var obstacle = _factory.Create();
                AddItem(obstacle);
                obstacle.transform.SetParent(transform);
                obstacle.rectTransform.anchoredPosition3D = new Vector3(currentPos, 0, 0);
                currentPos += _strategy.DistanceToGenerate;
            }
        }
    }
}