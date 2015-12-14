// Created 14.12.2015
// Modified by  14.12.2015 at 10:53

namespace Assets.Scripts.Gameplay.Heroes.JumpEngines {
    #region References

    using UnityEngine;

    #endregion

    internal class RigidbodyJumpEngine : HeroJumpingEngine {
        [SerializeField]
        private Rigidbody2D _rigidbody;

        public override void Jump(float force) {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.y, force);
        }
    }
}