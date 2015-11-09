// Created 09.11.2015 
// Modified by Gorbach Alex 09.11.2015 at 17:29

namespace Assets.Scripts.State.Progress.Score {
    #region References

    using System;

    #endregion

    internal interface IScoreSource {
        /// <summary>
        /// Called when current score has changed
        /// </summary>
        event Action<int> ScoreChanged;
    }
}