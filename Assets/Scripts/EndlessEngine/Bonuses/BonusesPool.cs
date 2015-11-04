// Created 28.10.2015 
// Modified by Gorbach Alex 04.11.2015 at 13:03

namespace Assets.Scripts.EndlessEngine.Bonuses {
    #region References

    using Engine.Factory.Strategy;
    using Engine.Pool;
    using Gameplay.Bonuses;
    using Zenject;

    #endregion

    internal class BonusesPool : GameObjectPool<Bonus> {
        [Inject]
        private IChooseStrategy<Bonus> _strategy;

        public override IChooseStrategy<Bonus> Strategy {
            get {
                return _strategy;
            }
        }
    }
}