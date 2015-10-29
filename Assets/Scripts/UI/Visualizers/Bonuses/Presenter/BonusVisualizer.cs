// Created 29.10.2015
// Modified by Александр 29.10.2015 at 21:34

namespace Assets.Scripts.UI.Visualizers.Bonuses.Presenter {
    #region References

    using EndlessEngine.Bonuses;
    using Gameplay.Bonuses;

    #endregion

    internal class BonusVisualizer : IBonusVisualizer {
        private readonly IBonusVisualizerUI _view;

        public BonusVisualizer(IBonusVisualizerUI view, IBonusGenerator generator) {
            _view = view;
            generator.BonusCollected += OnCollected;
        }

        private void OnCollected(IBonus bonus) {
            _view.AddBonus(bonus);
        }
    }
}