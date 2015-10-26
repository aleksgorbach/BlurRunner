// Created 20.10.2015
// Modified by Александр 26.10.2015 at 21:13

namespace Assets.Scripts.State.Levels {
    #region References

    using DataContracts.Models.Levels;

    #endregion

    internal interface ILevel {
        int Number { get; }
        Difficulty Difficulty { get; }
        float Length { get; }
    }
}