// Created 28.10.2015 
// Modified by Gorbach Alex 28.10.2015 at 11:12

namespace Assets.Scripts.Gameplay.Bonuses {
    #region References

    using UI;

    #endregion

    internal class Bonus : IBonus {
        private readonly IBonusUI _view;

        public Bonus(IBonusUI view) {
            _view = view;
        }
    }
}