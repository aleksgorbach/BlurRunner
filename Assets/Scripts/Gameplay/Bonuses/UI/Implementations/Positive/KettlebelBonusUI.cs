// Created 02.11.2015 
// Modified by Gorbach Alex 02.11.2015 at 9:16

namespace Assets.Scripts.Gameplay.Bonuses.UI.Implementations.Positive {
    #region References

    using Bonuses.Implementations.Positive;

    #endregion

    internal class KettlebelBonusUI : PositiveBonusUI {
        protected override IBonus GetBonus() {
            return new KettlebellBonus();
        }
    }
}