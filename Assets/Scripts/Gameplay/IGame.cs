// Created 24.10.2015
// Modified by Александр 05.11.2015 at 19:53

namespace Assets.Scripts.Gameplay {
    #region References

    using State.Levels;
    using State.Progress;

    #endregion

    internal interface IGame {
        ILevelProgress Progress { get; }
        void StartLevel(ILevel level);
    }
}