// Created 26.11.2015
// Modified by Александр 26.11.2015 at 19:42

namespace Assets.Scripts.EndlessEngine.Levels {
    #region References

    using System;
    using State.Levels;

    #endregion

    internal interface ILevelGenerator {
        void Generate(ILevel level);
        event Action Generated;
    }
}