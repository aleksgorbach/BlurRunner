// Created 02.11.2015
// Modified by Александр 02.11.2015 at 20:29

namespace Assets.Scripts.EndlessEngine.Bonuses {
    #region References

    using System;
    using Gameplay.Bonuses;

    #endregion

    internal interface IBonusGenerator {
        event Action<Bonus> BeginCollect;
        event Action<Bonus> EndCollect;
        event Action<Bonus> Removed;
    }
}