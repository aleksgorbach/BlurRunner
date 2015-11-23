// Created 10.11.2015
// Modified by  23.11.2015 at 12:57

namespace Assets.Scripts.EndlessEngine.Background {
    #region References

    using System.Collections.Generic;
    using Engine.Factory;
    using Engine.Factory.Strategy;
    using UnityEngine;

    #endregion

    internal class HillFactory : AbstractGameObjectFactory<HillItem> {
        [SerializeField]
        private HillItem[] _prefabs;

        [SerializeField]
        private HillStrategy _strategy;

        protected override ChooseStrategy<HillItem> Strategy {
            get { return _strategy; }
        }

        protected override IEnumerable<HillItem> Items {
            get { return _prefabs; }
        }

        protected override void Start() {
            base.Start();
            OnLoaded();
        }
    }
}