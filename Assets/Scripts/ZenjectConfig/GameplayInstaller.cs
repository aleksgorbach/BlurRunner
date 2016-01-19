// Created 20.10.2015
// Modified by  19.01.2016 at 15:23

namespace Assets.Scripts.ZenjectConfig {
    #region References

    using EndlessEngine.Bonuses;
    using EndlessEngine.Decorations;
    using EndlessEngine.Ground;
    using EndlessEngine.Obstacles;
    using Engine;
    using Engine.Factory;
    using Engine.Factory.ChooseStrategies;
    using Engine.Video;
    using Gameplay;
    using Gameplay.Bonuses;
    using Gameplay.Consts;
    using Gameplay.GameState.Manager;
    using State;
    using State.Levels;
    using State.Levels.Storage;
    using State.Progress.Storage;
    using State.ScenesInteraction.Loaders;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class GameplayInstaller : MonoInstaller {
        #region Visible in inspector

        [SerializeField]
        private Game _game;

        [SerializeField]
        private WorldLoader _worldLoader;

        #endregion

        public override void InstallBindings() {
            Container.Bind<IGame>().ToInstance(_game);
            Container.Bind<IGameStateManager>().ToSingle<GameStateManager>();
            Container.Bind<Camera>().ToSingleInstance(Camera.main);
            Container.Bind<ILevel>().ToGetter<ILevelStorage>(storage => storage.CurrentLevel);
            Container.Bind<string>(Identifiers.Obstacles.Layer).ToInstance("Obstacle");

            Container.Bind<int>(Identifiers.Levels.CurrentLevel)
                .ToGetter<ILevelStorage>(storage => storage.CurrentLevel.Number);

            Container.Bind<AbstractGameObjectFactory<Obstacle>>().ToTransient<ObstacleFactory>();
            Container.Bind<AbstractGameObjectFactory<GroundBlock>>().ToTransient<GroundFactory>();
            Container.Bind<AbstractGameObjectFactory<Bonus>>().ToTransient<BonusFactory>();
            Container.Bind<AbstractGameObjectFactory<Decoration>>().ToTransient<DecorationsFactory>();

            Container.Bind<IChooseStrategy<Decoration>>().ToTransient<RandomStrategy<Decoration>>();
            Container.Bind<IChooseStrategy<Bonus>>().ToTransient<ChanceStrategy<Bonus>>();
            Container.Bind<IChooseStrategy<Obstacle>>().ToTransient<RandomStrategy<Obstacle>>();
            Container.Bind<IChooseStrategy<GroundBlock>>().ToTransient<CompatibleStrategy<GroundBlock>>();
            Container.Bind<IVideoPlatform>().ToTransient<MobileVideoPlatform>();
            Container.Bind<string>(Identifiers.Video.Intro).ToInstance("tizer.mp4");
            Container.Bind<IWorldLoader>().ToInstance(_worldLoader);

            Container.Bind<IGameStartedHandler>().ToTransient<ProgressStorage>();
            Container.Bind<IGameLoopUpdatable>().ToTransient<ProgressStorage>();

            InstallLevelSettings();
        }

        private void InstallLevelSettings() {
        }
    }
}