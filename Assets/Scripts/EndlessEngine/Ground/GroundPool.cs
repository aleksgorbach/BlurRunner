// Created 20.10.2015 
// Modified by Gorbach Alex 04.11.2015 at 13:03

namespace Assets.Scripts.EndlessEngine.Ground {
    #region References

    using Engine.Factory.Strategy;
    using Engine.Pool;
    using UI;
    using Zenject;

    #endregion

    internal class GroundPool : GameObjectPool<GroundBlock> {
        [Inject]
        private IChooseStrategy<GroundBlock> _strategy;

        public override IChooseStrategy<GroundBlock> Strategy {
            get {
                return _strategy;
            }
        }
    }
}