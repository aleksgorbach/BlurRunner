// Created 20.10.2015
// Modified by  19.11.2015 at 15:36

#region References

#endregion

namespace Assets.Scripts.ZenjectConfig {
    #region References

    using System;
    using EndlessEngine.Bonuses;
    using Gameplay;
    using Gameplay.Consts;
    using Gameplay.GameState.Manager;
    using Gameplay.GameState.StateChangedSources;
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
            //Container.Bind<ILevelProgress>().ToGetter<IProgressStorage>(x => x.CurrentLevelProgress);
            Container.BindIFactory<ILevelProgress>().ToFactory<LevelProgress>();
            Container.Bind<ILevelProgress>().ToGetter<IGame>(x => x.Progress);
            Container.Bind<IScoreSource>().ToInstance(_bonusGenerator);
            Container.Bind<int>(Identifiers.Scores.MinValue).ToInstance(_scoreSettings.ScoreToLose);
        }

        [Serializable]
        public class ScoreSettings {
            public int ScoreToLose;
        }
    }
}