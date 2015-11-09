// Created 09.11.2015 
// Modified by Gorbach Alex 09.11.2015 at 10:14

namespace Assets.Scripts.EndlessEngine.Background {
    #region References

    using Engine.Factory;
    using Engine.Factory.Strategy;
    using Engine.Pool;
    using UnityEngine;

    #endregion

    internal class BackgroundPool : GameObjectPool<HillItem> {
        [SerializeField]
        private HillFactory _factory;

        [SerializeField]
        private HillStrategy _strategy;

        protected override IFactory<HillItem> Factory {
            get {
                return _factory;
            }
        }

        public override IChooseStrategy<HillItem> Strategy {
            get {
                return _strategy;
            }
        }
    }
}