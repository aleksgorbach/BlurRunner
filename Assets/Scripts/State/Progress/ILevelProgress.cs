// Created 09.11.2015 
// Modified by Gorbach Alex 10.11.2015 at 11:42

namespace Assets.Scripts.State.Progress {
    #region References

    using System;

    #endregion

    internal interface ILevelProgress {
        int Number { get; }
        int Score { get; set; }

        event Action<int> Changed;
        event Action BecomeNegative;
    }
}