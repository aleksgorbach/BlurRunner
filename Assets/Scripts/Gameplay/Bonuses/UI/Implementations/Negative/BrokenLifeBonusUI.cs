// Created 02.11.2015 
// Modified by Gorbach Alex 02.11.2015 at 9:35

namespace Assets.Scripts.Gameplay.Bonuses.UI.Implementations.Negative {
    #region References

    using Assets.Scripts.Gameplay.Bonuses.Implementations.Negative;

    #endregion

    internal class BrokenLifeBonusUI : NegativeBonusUI {
        protected override IBonus GetBonus() {
            return new BrokenLifeBonus();
        }
    }
}