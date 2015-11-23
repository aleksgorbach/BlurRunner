// Created 22.10.2015
// Modified by  23.11.2015 at 13:04

namespace Assets.Scripts.State.Levels {
    #region References

    using EndlessEngine.Decorations;
    using EndlessEngine.Obstacles;
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

        DecorationItem[] Decorations { get; }

        Obstacle[] Obstacles { get; }
    }
}