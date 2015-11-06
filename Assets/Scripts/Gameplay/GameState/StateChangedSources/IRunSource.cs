// Created 06.11.2015 
// Modified by Gorbach Alex 06.11.2015 at 8:33

namespace Assets.Scripts.Gameplay.GameState.StateChangedSources {
    #region References

    using System;

    #endregion

    internal interface IRunSource {
        event Action Run;
    }
}