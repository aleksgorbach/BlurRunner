// Created 29.10.2015
// Modified by Александр 29.10.2015 at 21:34

namespace Assets.Scripts.UI.Visualizers.Bonuses {
    #region References

    using Gameplay.Bonuses;

    #endregion

    internal interface IBonusVisualizerUI {
        void AddBonus(IBonus bonus);
    }
}