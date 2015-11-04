// Created 03.11.2015 
// Modified by Gorbach Alex 04.11.2015 at 13:03

namespace Assets.Scripts.EndlessEngine.Decorations {
    #region References

    using Engine.Factory.Strategy;
    using Engine.Pool;
    using Zenject;

    #endregion

    internal class DecorationPool : GameObjectPool<DecorationItem> {
        [Inject]
        private IChooseStrategy<DecorationItem> _strategy;

        public override IChooseStrategy<DecorationItem> Strategy {
            get {
                return _strategy;
            }
        }
    }
}