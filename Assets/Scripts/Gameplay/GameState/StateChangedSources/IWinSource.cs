// Created 05.11.2015
// Modified by  14.01.2016 at 9:03

namespace Assets.Scripts.Gameplay.GameState.StateChangedSources {
    #region References

    using System;

    #endregion

    internal interface IWinSource {
        event EventHandler<WinSourceArgs> Win;
    }
}