// Created 26.10.2015
// Modified by  18.12.2015 at 16:28

namespace Assets.Scripts.Gameplay.GameState.Manager {
    #region References

    using System;
    using Consts;

    #endregion

    internal delegate void StateChangedDelegate(GameState state);

    internal interface IGameStateManager {
        GameState State { get; }
        event StateChangedDelegate StateChanged;

        void Pause();

        void Resume();

        void Run();

        void AddWinReason(Func<bool> reason);
    }
}