// Created 30.11.2015
// Modified by Александр 03.12.2015 at 20:51

namespace Assets.Scripts.State.Levels {
    #region References

    using EndlessEngine.Decorations;
    using EndlessEngine.Ground;
    using EndlessEngine.Obstacles;
    using Gameplay.Bonuses;
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

        Decoration[] Decorations { get; }

        Obstacle[] Obstacles { get; }
        GroundBlock[] Ground { get; }
        GroundBlock[] Hills { get; }
        Bonus[] Bonuses { get; }
    }
}