// Created 26.10.2015
// Modified by  28.12.2015 at 10:41

namespace Assets.Scripts.Gameplay {
    #region References

    using System;
    using Heroes;
    using State.Progress;

    #endregion

    internal interface IGame {
        ILevelProgress Progress { get; }
        event EventHandler<Hero.HeroSpawnedEventArgs> HeroSpawned;
    }
}