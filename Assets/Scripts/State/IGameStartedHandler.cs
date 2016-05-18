// Created 19.01.2016
// Modified by  19.01.2016 at 14:41

namespace Assets.Scripts.State {
    #region References

    using Gameplay;

    #endregion

    internal interface IGameStartedHandler {
        void OnGameStarted(IGame game);
    }
}