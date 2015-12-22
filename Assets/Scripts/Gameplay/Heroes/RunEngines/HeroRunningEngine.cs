// Created 14.12.2015
// Modified by  22.12.2015 at 10:39

namespace Assets.Scripts.Gameplay.Heroes.RunEngines {
    #region References

    using Engine;

    #endregion

    internal abstract class HeroRunningEngine : MonoBehaviourBase {
        protected bool Running { get; private set; }
        protected float Speed { get; private set; }

        public virtual void Run(float speed) {
            Speed = speed;
            Running = true;
        }

        public virtual void Stop() {
            Speed = 0;
            Running = false;
        }
    }
}