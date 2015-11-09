// Created 09.11.2015 
// Modified by Gorbach Alex 09.11.2015 at 17:33

#region References

#endregion

namespace Assets.Scripts.ZenjectConfig {
    #region References

    using EndlessEngine.Bonuses;
    using State.Progress.Score;
    using Gameplay;
    using Gameplay.GameState.Manager;
    using Gameplay.GameState.StateChangedSources;
    using State.Progress;
    using State.Progress.Storage;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class GameplayInstaller : MonoInstaller {
        [SerializeField]
        private Game _game;

        [SerializeField]
        private BonusGenerator _bonusGenerator;

        public override void InstallBindings() {
            Container.Bind<IGame>().ToInstance(_game);
            Container.Bind<IGameStateManager>().ToSingle<GameStateManager>();
            Container.Bind<Camera>().ToSingleInstance(Camera.main);
            Container.Bind<IWinSource>().ToInstance(_game);
            Container.Bind<ILevelProgress>().ToGetter<IProgressStorage>(x => x.CurrentLevelProgress);
            Container.Bind<IScoreSource>().ToInstance(_bonusGenerator);
        }
    }
}