// Created 20.10.2015
// Modified by Александр 01.11.2015 at 12:46

namespace Assets.Scripts.State.Levels {
    #region References

    using Gameplay.Heroes;
    using UnityEngine;

    #endregion

    internal interface ILevel {
        int Number { get; }
        Sprite Background { get; }
        Hero Hero { get; }
        //float Length { get; }
        //Difficulty Difficulty { get; }
    }
}