// Created 14.12.2015
// Modified by  20.01.2016 at 13:00

namespace Assets.Scripts.Gameplay.Heroes.RunEngines {
    #region References

    using Engine;
    using UnityEngine;

    #endregion

    internal abstract class HeroRunningEngine : MonoBehaviourBase {
        public abstract void Run(float speed);
        public abstract Vector2 Speed { get; }
    }
}