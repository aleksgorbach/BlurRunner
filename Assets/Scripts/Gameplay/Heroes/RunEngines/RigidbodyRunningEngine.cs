// Created 14.12.2015
// Modified by  23.12.2015 at 9:06

namespace Assets.Scripts.Gameplay.Heroes.RunEngines {
    #region References

    using UnityEngine;

    #endregion

    internal class RigidbodyRunningEngine : HeroRunningEngine {
        [SerializeField]
        private Rigidbody2D _rigidbody;

        private void FixedUpdate() {
            _rigidbody.velocity = new Vector2(Running ? Speed : 0, _rigidbody.velocity.y);
        }
    }
}