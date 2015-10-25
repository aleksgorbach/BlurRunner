// Created 24.10.2015
// Modified by Александр 25.10.2015 at 10:47

namespace Assets.Scripts.Gameplay.GameState.Manager {
    #region References

    using Consts;

    #endregion

    internal delegate void StateChangedDelegate(GameState state);

    internal interface IGameStateManager {
        GameState State { get; }
        event StateChangedDelegate StateChanged;
    }
}