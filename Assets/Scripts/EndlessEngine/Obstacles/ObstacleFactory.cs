// Created 20.11.2015
// Modified by  27.11.2015 at 10:50

namespace Assets.Scripts.EndlessEngine.Obstacles {
    #region References

    using Engine.Extensions;
    using Engine.Factory;
    using Zenject;

    #endregion

    internal class ObstacleFactory : AbstractGameObjectFactory<Obstacle> {
        public Obstacle Create() {
            return Container.InstantiatePrefabForComponent<Obstacle>(Prefabs.Random().gameObject);
        }
    }
}