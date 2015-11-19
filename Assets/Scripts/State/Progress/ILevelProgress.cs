// Created 22.10.2015
// Modified by  19.11.2015 at 15:07

namespace Assets.Scripts.State.Progress {
    #region References

    using System;

    #endregion

    internal interface ILevelProgress {
        int Score { get; set; }

        event Action<int> Changed;
    }
}