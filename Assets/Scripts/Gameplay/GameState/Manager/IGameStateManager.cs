// Created 26.10.2015
// Modified by  14.01.2016 at 9:06

namespace Assets.Scripts.Gameplay.GameState.Manager {
    #region References

    using System;
    using Consts;

    #endregion

    internal delegate void StateChangedDelegate(GameState state);

    internal interface IGameStateManager {
        GameState State { get; }
        event EventHandler<GameStateChangedArgs> StateChanged;

        void Pause();

        void Resume();

        void Run();
    }
}