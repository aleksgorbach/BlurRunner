// Created 14.12.2015
// Modified by  21.01.2016 at 10:57

namespace Assets.Scripts.Gameplay.Heroes.JumpEngines {
    #region References

    using UnityEngine;

    #endregion

    internal class RigidbodyJumpEngine : HeroJumpingEngine {
        [SerializeField]
        private Rigidbody2D _rigidbody;

        public override void Jump() {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.y, Force);
        }
    }
}