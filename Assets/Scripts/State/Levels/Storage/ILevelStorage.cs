// Created 15.10.2015
// Modified by Александр 01.11.2015 at 17:26

namespace Assets.Scripts.State.Levels.Storage {
    #region References

    using System.Collections.Generic;

    #endregion

    internal interface ILevelStorage : IEnumerable<ILevel> {
        ILevel this[int levelNumber] { get; }
    }
}