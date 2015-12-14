// Created 20.10.2015
// Modified by  14.12.2015 at 14:32

#region References

#endregion

namespace Assets.Scripts.ZenjectConfig {
    #region References

    using System;
    using EndlessEngine.Bonuses;
    using EndlessEngine.Decorations;
    using EndlessEngine.Ground;
    using EndlessEngine.Obstacles;
    using Engine.Factory;
    using Engine.Factory.ChooseStrategies;
    using Engine.Video;
    using Gameplay;
    using Gameplay.Bonuses;
    using Gameplay.Consts;
    using Gameplay.GameState.Manager;
    using Gameplay.GameState.StateChangedSources;
    using State.Levels;
    using State.Levels.Storage;
    using State.Progress;
    using State.Progress.Score;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class GameplayInstaller : MonoInstaller {
        [SerializeField]
        private Bonuses _bonusGenerator;

        [SerializeField]
        private Game _game;

        [SerializeField]
        private ScoreSettings _scoreSettings;

        public override void InstallBindings() {
            Container.Bind<IGame>().ToInstance(_game);
            Container.Bind<IGameStateManager>().ToSingle<GameStateManager>();
            Container.Bind<Camera>().ToSingleInstance(Camera.main);
            Container.Bind<IWinSource>().ToInstance(_game);
            Container.Bind<ILevelProgress>().ToSingleInstance(new LevelProgress());
            Container.Bind<IScoreSource>().ToInstance(_bonusGenerator);
            Container.Bind<int>(Identifiers.Scores.MinValue).ToInstance(_scoreSettings.ScoreToLose);
            Container.Bind<ILevel>().ToGetter<ILevelStorage>(storage => storage.CurrentLevel);
            Container.Bind<string>(Identifiers.Obstacles.Layer).ToInstance("Obstacle");

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

            InstallLevelSettings();
        }

        private void InstallLevelSettings() {
            Container.Bind<Decoration[]>().ToGetter<ILevel>(level => level.Decorations);
            Container.Bind<Obstacle[]>().ToGetter<ILevel>(level => level.Obstacles);
        }

        [Serializable]
        public class ScoreSettings {
            public int ScoreToLose;
        }
    }
}