// Created 14.12.2015
// Modified by  21.01.2016 at 10:52

namespace Assets.Scripts.Gameplay.Heroes.JumpEngines {
    #region References

    using Engine;
    using UnityEngine;

    #endregion

    internal abstract class HeroJumpingEngine : MonoBehaviourBase {
        [SerializeField]
        private float _force;

        protected float Force {
            get { return _force; }
        }

        public abstract void Jump();
    }
}