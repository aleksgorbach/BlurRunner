// Created 26.10.2015
// Modified by Александр 27.10.2015 at 20:23

namespace Assets.Scripts.State.Levels.Loaders {
    #region References

    using System;
    using System.Collections.Generic;
    using Data;

    #endregion

    internal interface ILevelLoader {
        void Load();
        event Action<List<LevelData>> Loaded;
    }
}