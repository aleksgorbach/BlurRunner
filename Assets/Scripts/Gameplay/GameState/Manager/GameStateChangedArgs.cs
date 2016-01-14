// Created 14.01.2016
// Modified by  14.01.2016 at 9:06

namespace Assets.Scripts.Gameplay.GameState.Manager {
    #region References

    using System;
    using Consts;

    #endregion

    internal class GameStateChangedArgs : EventArgs {
        public readonly GameState State;

        public GameStateChangedArgs(GameState state) {
            State = state;
        }
    }
}