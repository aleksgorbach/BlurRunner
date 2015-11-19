// Created 20.10.2015
// Modified by Александр 19.11.2015 at 21:08

namespace Assets.Scripts.State.Levels {
    #region References

    using Gameplay.Heroes;
    using UnityEngine;

    #endregion

    internal interface ILevel {
        int Number { get; }
        Sprite Background { get; }
        Hero Hero { get; }
        Sprite Startpoint { get; }

        /// <summary>
        /// Hero's position at those level ends
        /// </summary>
        float Length { get; }

        //Difficulty Difficulty { get; }
    }
}