// Created 05.11.2015 
// Modified by Gorbach Alex 05.11.2015 at 12:44

namespace Assets.Scripts.Gameplay.GameState.StateChangedSources {
    #region References

    using System;

    #endregion

    internal interface IWinSource {
        event Action<IWinSource> Win;
    }
}