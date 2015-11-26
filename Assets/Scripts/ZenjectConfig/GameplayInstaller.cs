// Created 26.11.2015
// Modified by Александр 26.11.2015 at 20:40

#region References

#endregion

namespace Assets.Scripts.ZenjectConfig {
    #region References

    using System;
    using EndlessEngine.Bonuses;
    using EndlessEngine.Decorations;
    using EndlessEngine.Ground;
    using EndlessEngine.Obstacles;
    using Gameplay;
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
        private BonusGenerator _bonusGenerator;

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
            Container.Bind<IGroundFactory>().ToTransient<GroundFactory>();
            InstallLevelSettings();
        }

        private void InstallLevelSettings() {
            Container.Bind<DecorationItem[]>().ToGetter<ILevel>(level => level.Decorations);
            Container.Bind<Obstacle[]>().ToGetter<ILevel>(level => level.Obstacles);
        }

        [Serializable]
        public class ScoreSettings {
            public int ScoreToLose;
        }
    }
}