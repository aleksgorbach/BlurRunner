// Created 15.10.2015
// Modified by Александр 27.10.2015 at 20:39

namespace Assets.Scripts.State.Levels.Storage {
    using System.Collections.Generic;

    internal interface ILevelStorage : IEnumerable<ILevel> {
        int TotalLevelsCount { get; }
        ILevel this[int levelNumber] { get; }
    }
}