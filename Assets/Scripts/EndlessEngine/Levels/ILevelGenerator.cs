// Created 26.11.2015
// Modified by Александр 26.11.2015 at 19:42

namespace Assets.Scripts.EndlessEngine.Levels {
    #region References

    using Gameplay.Heroes;
    using State.Levels;

    #endregion

    internal interface ILevelGenerator {
        Hero Generate(ILevel level);
    }
}