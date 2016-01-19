// Created 26.10.2015
// Modified by  28.12.2015 at 10:41

namespace Assets.Scripts.Gameplay {
    #region References

    using System;
    using Events;

    #endregion

    internal interface IGame {
        event EventHandler<GameStartedEventArgs> Started;
        event EventHandler<GameFinishedEventArgs> Finished;
        event EventHandler<GameWinEventArgs> Win;
        event EventHandler<GameLoseEventArgs> Lose;
        event EventHandler<GameProgressChangedArgs> ProgressChanged;
        float Progress { get; }
        float PerfectLevelTime { get; }
    }
}