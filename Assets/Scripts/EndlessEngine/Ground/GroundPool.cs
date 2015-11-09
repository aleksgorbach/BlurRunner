// Created 09.11.2015 
// Modified by Gorbach Alex 09.11.2015 at 8:44

namespace Assets.Scripts.EndlessEngine.Ground {
    #region References

    using Engine.Factory.Strategy;
    using Engine.Pool;
    using UnityEngine;

    #endregion

    internal class GroundPool : GameObjectPool<GroundBlock> {
        [SerializeField]
        private GroundFactory _factory;

        [SerializeField]
        private GroundStrategy _strategy;

        protected override Engine.Factory.IFactory<GroundBlock> Factory {
            get {
                return _factory;
            }
        }

        public override IChooseStrategy<GroundBlock> Strategy {
            get {
                return _strategy;
            }
        }
    }
}