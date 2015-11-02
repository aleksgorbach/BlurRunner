// Created 02.11.2015 
// Modified by Gorbach Alex 02.11.2015 at 9:21

namespace Assets.Scripts.Gameplay.Bonuses.UI.Implementations.Positive {
    #region References

    using Assets.Scripts.Gameplay.Bonuses.Implementations.Positive;

    #endregion

    internal class VitamineBonusUI : PositiveBonusUI {
        protected override IBonus GetBonus() {
            return new VitamineBonus();
        }
    }
}