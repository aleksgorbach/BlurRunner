// Created 20.10.2015
// Modified by Александр 05.11.2015 at 19:16

namespace Assets.Scripts.State.Levels {
    #region References

    using Gameplay.Heroes;
    using UnityEngine;

    #endregion

    internal interface ILevel {
        int Number { get; }
        Sprite Background { get; }
        Hero Hero { get; }

        /// <summary>
        /// Hero's position at those level ends
        /// </summary>
        float Length { get; }

        //Difficulty Difficulty { get; }
    }
}