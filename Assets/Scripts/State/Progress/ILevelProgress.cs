// Created 22.10.2015 
// Modified by Gorbach Alex 11.11.2015 at 12:28

namespace Assets.Scripts.State.Progress {
    #region References

    using System;

    #endregion

    internal interface ILevelProgress {
        int Number { get; }
        int Score { get; set; }

        event Action<int> Changed;
    }
}