// Created 26.10.2015
// Modified by  22.12.2015 at 10:07

namespace Assets.Scripts.Gameplay.GameState.Manager {
    #region References

    using System;
    using Consts;
    using StateChangedSources;

    #endregion

    internal delegate void StateChangedDelegate(GameState state);

    internal interface IGameStateManager {
        GameState State { get; }
        IWinSource Target { set; }
        event StateChangedDelegate StateChanged;

        void Pause();

        void Resume();

        void Run();
    }
}