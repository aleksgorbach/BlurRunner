// Created 28.12.2015
// Modified by  28.12.2015 at 10:33

namespace Assets.Scripts.State.ScenesInteraction.Loaders {
    #region References

    using System;

    #endregion

    internal interface IWorldLoader {
        event EventHandler<WorldLoader.WorldLoadedEventArgs> WorldLoaded;
    }
}