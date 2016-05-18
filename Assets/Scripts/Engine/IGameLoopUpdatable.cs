// Created 19.01.2016
// Modified by  19.01.2016 at 15:04

namespace Assets.Scripts.Engine {
    #region References

    using Gameplay;

    #endregion

    internal interface IGameLoopUpdatable {
        void Update(IGame game);
    }
}