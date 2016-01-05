// Created 20.10.2015
// Modified by  23.11.2015 at 10:52

namespace Assets.Scripts.State.Levels.Storage {
    #region References

    using System.Collections.Generic;

    #endregion

    internal interface ILevelStorage : IEnumerable<ILevel> {
        ILevel this[int levelNumber] { get; }
        ILevel CurrentLevel { get; }
        void SetCurrentLevel(int levelNumber);
    }
}