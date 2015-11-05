// Created 21.10.2015
// Modified by Александр 05.11.2015 at 20:09

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