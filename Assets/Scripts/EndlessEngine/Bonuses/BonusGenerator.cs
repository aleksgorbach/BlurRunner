// Created 28.10.2015 
// Modified by Gorbach Alex 28.10.2015 at 14:58

namespace Assets.Scripts.EndlessEngine.Bonuses {
    #region References

    using Strategy;
    using Gameplay.Bonuses.UI;
    using UI;
    using Engine.Pool;

    #endregion

    internal class BonusGenerator : IBonusGenerator {
        private readonly IBonusGeneratorUI _view;
        private readonly IObjectPool<BonusUI> _pool;

        public BonusGenerator(IBonusGeneratorUI view, IObjectPool<BonusUI> pool, IBonusStrategy strategy) {
            _view = view;
            _pool = pool;
            strategy.BonusNeed += GenerateBonus;
            view.Collected += Release;
        }

        private void Release(BonusUI bonus) {
            _pool.Release(bonus);
        }

        private void GenerateBonus() {
            var bonus = _pool.Get();
            bonus.gameObject.SetActive(true);
            _view.Add(bonus);
        }
    }
}