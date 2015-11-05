// Created 02.11.2015
// Modified by Александр 05.11.2015 at 20:34

namespace Assets.Scripts.Gameplay.Bonuses {
    #region References

    using System;

    #endregion

    internal interface IBonus {
        int Points { get; }

        void Apply();
        event Action<Bonus> Collected;
        event Action<Bonus> EndCollected;
    }
}