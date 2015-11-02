// Created 02.11.2015
// Modified by Александр 02.11.2015 at 20:27

namespace Assets.Scripts.Gameplay.Bonuses {
    #region References

    using System;

    #endregion

    internal interface IBonus {
        float Strength { get; }
        
        void Apply();
        event Action<Bonus> BeginCollect;
        event Action<Bonus> EndCollect;
    }
}