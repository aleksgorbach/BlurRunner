// Created 26.10.2015 
// Modified by Gorbach Alex 26.10.2015 at 13:42

namespace Assets.Scripts.EndlessEngine.Ground.Decorations {
    #region References

    using Strategy;
    using Ground.UI;
    using UI;
    using Engine.Pool;
    using JetBrains.Annotations;

    #endregion

    internal class DecorationGenerator : IDecorationGenerator {
        private readonly IDecorationGeneratorUI _view;
        private readonly IObjectPool<DecorationItemUI> _pool;
        private readonly IGeneratingStrategy _strategy;

        public DecorationGenerator(
            IDecorationGeneratorUI view,
            IObjectPool<DecorationItemUI> pool,
            IGroundGenerator groundGenerator,
            IGeneratingStrategy strategy) {
            _view = view;
            _pool = pool;
            _strategy = strategy;
            groundGenerator.BlockCreated += OnBlockCreated;
            groundGenerator.BlockRemoved += OnBlockRemoved;
        }

        private void OnBlockRemoved(GroundBlockUI block) {
        }

        private void OnBlockCreated(GroundBlockUI block) {
            if (_strategy.IsGeneratingNeeded) {
                var created = Get();
                _view.Add(created, block);
            }
        }

        private DecorationItemUI Get() {
            var obj = _pool.Get();
            obj.gameObject.SetActive(true);
            return obj;
        }

        private void Release(DecorationItemUI item) {
            _pool.Release(item);
        }
    }
}