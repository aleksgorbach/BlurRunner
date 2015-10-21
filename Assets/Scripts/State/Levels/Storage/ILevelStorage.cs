// Created 15.10.2015
// Modified by Александр 15.10.2015 at 20:48

namespace Assets.Scripts.State.Levels.Storage {
    using System.Collections.Generic;

    internal interface ILevelStorage {
        int TotalLevelsCount { get; }
        IEnumerable<ILevel> Get(int fromLevel, int toLevel);
        ILevel this[int levelNumber] { get; }
    }
}