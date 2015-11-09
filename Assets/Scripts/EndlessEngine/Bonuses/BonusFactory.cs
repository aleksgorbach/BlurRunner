// Created 08.11.2015
// Modified by Александр 08.11.2015 at 20:57

namespace Assets.Scripts.EndlessEngine.Bonuses {
    #region References

    using System.Collections.Generic;
    using Engine.Factory;
    using Engine.Factory.Strategy;
    using Gameplay.Bonuses;
    using UnityEngine;

    #endregion

    internal class BonusFactory : AbstractGameObjectFactory<Bonus> {
        [SerializeField]
        private Bonus[] _prefabs;

        [SerializeField]
        private BonusStrategy _strategy;

        protected override ChooseStrategy<Bonus> Strategy {
            get { return _strategy; }
        }

        protected override IEnumerable<Bonus> Items {
            get { return _prefabs; }
        }
    }
}