// Created 04.11.2015
// Modified by Александр 08.11.2015 at 21:02

namespace Assets.Scripts.EndlessEngine.Bonuses {
    #region References

    using Engine.Factory.Strategy;
    using Engine.Pool;
    using Gameplay.Bonuses;
    using UnityEngine;

    #endregion

    internal class BonusesPool : GameObjectPool<Bonus> {
        [SerializeField]
        private BonusFactory _factory;

        [SerializeField]
        private BonusStrategy _strategy;

        protected override Engine.Factory.IFactory<Bonus> Factory {
            get { return _factory; }
        }

        public override IChooseStrategy<Bonus> Strategy {
            get { return _strategy; }
        }
    }
}