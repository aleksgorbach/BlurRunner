// Created 26.10.2015
// Modified by  24.12.2015 at 10:40

namespace Assets.Scripts.Gameplay {
    #region References

    using System;
    using Heroes;
    using State.Progress;
    using State.ScenesInteraction.Loaders;

    #endregion

    internal interface IGame {
        ILevelProgress Progress { get; }
        event EventHandler<WorldLoader.WorldLoadedEventArgs> WorldLoaded;
        event EventHandler<Hero.HeroSpawnedEventArgs> HeroSpawned;
    }
}