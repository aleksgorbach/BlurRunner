// Created 14.12.2015
// Modified by  21.01.2016 at 10:57

namespace Assets.Scripts.Gameplay.Heroes.RunEngines {
    #region References

    using UnityEngine;

    #endregion

    internal class RigidbodyRunningEngine : HeroRunningEngine {
        [SerializeField]
        private Rigidbody2D _rigidbody;

        public override void Run() {
            _rigidbody.velocity = new Vector2(Force, _rigidbody.velocity.y);
        }

        public override Vector2 Speed {
            get { return _rigidbody.velocity; }
        }
    }
}