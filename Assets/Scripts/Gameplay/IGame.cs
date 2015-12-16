// Created 24.10.2015
// Modified by Александр 16.12.2015 at 21:44

namespace Assets.Scripts.Gameplay {
    #region References

    using State.Progress;
    using State.ScenesInteraction.Loaders;

    #endregion

    internal interface IGame {
        ILevelProgress Progress { get; }
        LevelWorld World { set; }
    }
}