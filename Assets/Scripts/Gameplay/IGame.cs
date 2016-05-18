// Created 26.10.2015
// Modified by  20.01.2016 at 13:54

namespace Assets.Scripts.Gameplay {
    #region References

    using System;
    using Events;
    using UnityEngine;

    #endregion

    internal interface IGame {
        event EventHandler<GameStartedEventArgs> Started;
        event EventHandler<GameFinishedEventArgs> Finished;
        event EventHandler<GameWinEventArgs> Win;
        event EventHandler<GameLoseEventArgs> Lose;
        event EventHandler<GameProgressChangedArgs> ProgressChanged;
        Vector2 CurrentHeroSpeed { get; }
        float LevelLength { get; }
        float NominalHeroSpeed { get; }
    }
}