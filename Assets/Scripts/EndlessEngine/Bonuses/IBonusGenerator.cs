// Created 28.10.2015 
// Modified by Gorbach Alex 28.10.2015 at 11:07

namespace Assets.Scripts.EndlessEngine.Bonuses {
    using System;
    using Gameplay.Bonuses;

    internal interface IBonusGenerator {
        event Action<IBonus> BonusCollected;
    }
}