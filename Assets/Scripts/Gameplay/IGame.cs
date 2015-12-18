// Created 26.10.2015
// Modified by  18.12.2015 at 16:11

namespace Assets.Scripts.Gameplay {
    #region References

    using State.Progress;

    #endregion

    internal interface IGame {
        ILevelProgress Progress { get; }
    }
}