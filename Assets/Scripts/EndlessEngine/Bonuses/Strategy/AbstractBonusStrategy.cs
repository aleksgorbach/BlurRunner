// Created 28.10.2015 
// Modified by Gorbach Alex 28.10.2015 at 11:42

namespace Assets.Scripts.EndlessEngine.Bonuses.Strategy {
    #region References

    using Assets.Scripts.Engine;

    #endregion

    internal abstract class AbstractBonusStrategy : MonoBehaviourBase, IBonusStrategy {
        public event BonusNeedDelegate BonusNeed;

        protected void OnBonusNeed() {
            var handler = BonusNeed;
            if (handler != null) {
                handler();
            }
        }
    }
}