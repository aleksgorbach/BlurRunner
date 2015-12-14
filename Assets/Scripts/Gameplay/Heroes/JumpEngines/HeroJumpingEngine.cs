// Created 14.12.2015
// Modified by  14.12.2015 at 10:52

namespace Assets.Scripts.Gameplay.Heroes.JumpEngines {
    #region References

    using Engine;

    #endregion

    internal abstract class HeroJumpingEngine : MonoBehaviourBase {
        public abstract void Jump(float force);
    }
}