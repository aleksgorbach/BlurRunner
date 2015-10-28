// Created 28.10.2015 
// Modified by Gorbach Alex 28.10.2015 at 11:27

namespace Assets.Scripts.EndlessEngine.Bonuses.Strategy {
    internal delegate void BonusNeedDelegate();

    internal interface IBonusStrategy {
        event BonusNeedDelegate BonusNeed;
    }
}