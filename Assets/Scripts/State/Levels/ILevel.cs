// Created 26.11.2015
// Modified by Александр 26.11.2015 at 20:26

namespace Assets.Scripts.State.Levels {
    #region References

    using EndlessEngine.Decorations;
    using EndlessEngine.Ground;
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
        GroundBlock[] Ground { get; }
    }
}