// Created 26.10.2015
// Modified by Александр 26.10.2015 at 21:16

namespace Assets.Scripts.State.Levels.Loaders {
    #region References

    using System;
    using System.Collections.Generic;
    using DataContracts.Models.Levels;

    #endregion

    internal interface ILevelLoader {
        void Load();
        event Action<IEnumerable<LevelData>> Loaded;
    }
}