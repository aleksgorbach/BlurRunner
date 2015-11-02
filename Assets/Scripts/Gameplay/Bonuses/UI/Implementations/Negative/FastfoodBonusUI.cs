// Created 02.11.2015 
// Modified by Gorbach Alex 02.11.2015 at 9:36

namespace Assets.Scripts.Gameplay.Bonuses.UI.Implementations.Negative {
    #region References

    using Bonuses.Implementations.Negative;

    #endregion

    internal class FastfoodBonusUI : NegativeBonusUI {
        protected override IBonus GetBonus() {
            return new FastfoodBonus();
        }
    }
}