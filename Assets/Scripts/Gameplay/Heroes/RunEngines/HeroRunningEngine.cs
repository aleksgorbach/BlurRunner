// Created 14.12.2015
// Modified by  22.12.2015 at 10:39

namespace Assets.Scripts.Gameplay.Heroes.RunEngines {
    #region References

    using Engine;

    #endregion

    internal abstract class HeroRunningEngine : MonoBehaviourBase {
        public abstract void Run(float speed);
    }
}