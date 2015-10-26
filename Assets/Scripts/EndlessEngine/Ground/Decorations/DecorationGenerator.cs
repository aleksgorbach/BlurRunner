// Created 26.10.2015
// Modified by Александр 26.10.2015 at 21:07

namespace Assets.Scripts.EndlessEngine.Ground.Decorations {
    #region References

    using Engine.Pool;
    using Ground.UI;
    using Strategy;
    using UI;

    #endregion

    internal class DecorationGenerator : IDecorationGenerator {
        private readonly IObjectPool<DecorationItemUI> _pool;
        private readonly IGeneratingStrategy _strategy;
        private readonly IDecorationGeneratorUI _view;

        public DecorationGenerator(
            IDecorationGeneratorUI view,
            IObjectPool<DecorationItemUI> pool,
            IGroundGenerator groundGenerator,
            IGeneratingStrategy strategy) {
            _view = view;
            _pool = pool;
            _strategy = strategy;
            groundGenerator.BlockCreated += OnBlockCreated;
            view.ItemHidden += Release;
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