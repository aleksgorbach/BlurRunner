// Created 26.10.2015 
// Modified by Gorbach Alex 11.11.2015 at 13:06

namespace Assets.Scripts.Gameplay.GameState.Manager {
    #region References

    using Consts;

    #endregion

    internal delegate void StateChangedDelegate(GameState state);

    internal interface IGameStateManager {
        GameState State { get; }
        event StateChangedDelegate StateChanged;

        void Pause();

        void Resume();
    }
}