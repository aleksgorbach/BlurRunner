// Created 26.10.2015
// Modified by  19.11.2015 at 14:29

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

        void Run();
    }
}