// Created 14.12.2015
// Modified by  21.01.2016 at 11:21

namespace Assets.Scripts.Gameplay.Heroes.RunEngines {
    #region References

    using Engine;
    using UnityEngine;

    #endregion

    internal abstract class HeroRunningEngine : MonoBehaviourBase {
        [SerializeField]
        private float _force;

        public abstract void Run();

        public float Force {
            get { return _force; }
        }

        public abstract Vector2 Speed { get; }

        public void Stop() {
            _force = 0;
        }
    }
}