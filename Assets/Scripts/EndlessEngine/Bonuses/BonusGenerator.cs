// Created 28.10.2015 
// Modified by Gorbach Alex 02.11.2015 at 10:09

namespace Assets.Scripts.EndlessEngine.Bonuses {
    #region References

    using System;
    using Engine.Pool;
    using Gameplay.Bonuses;
    using Gameplay.Bonuses.UI;
    using Strategy;
    using UI;

    #endregion

    internal class BonusGenerator : IBonusGenerator {
        private readonly IObjectPool<BonusUI> _pool;
        private readonly IBonusGeneratorUI _view;

        public BonusGenerator(IBonusGeneratorUI view, IObjectPool<BonusUI> pool, IBonusStrategy strategy) {
            _view = view;
            _pool = pool;
            strategy.BonusNeed += GenerateBonus;
            view.Collected += OnBonusCollected;
            view.Collect += OnBonusCollect;
            view.RemoveNeeded += Remove;
        }

        public event Action<IBonus> BonusCollected;

        private void OnBonusCollect(BonusUI bonus) {
            OnCollected(bonus.Bonus);
        }

        private void Remove(BonusUI bonus) {
            _view.RemoveBonus(bonus);
            Release(bonus);
        }

        private void Release(BonusUI bonus) {
            _pool.Release(bonus);
        }

        private void OnBonusCollected(BonusUI bonus) {
            Release(bonus);
        }

        private void GenerateBonus() {
            var bonus = _pool.Get();
            bonus.gameObject.SetActive(true);
            _view.Add(bonus);
        }

        private void OnCollected(IBonus bonus) {
            var handler = BonusCollected;
            if (handler != null) {
                handler.Invoke(bonus);
            }
        }
    }
}