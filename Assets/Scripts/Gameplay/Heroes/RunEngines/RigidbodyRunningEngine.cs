// Created 14.12.2015
// Modified by  22.12.2015 at 10:39

namespace Assets.Scripts.Gameplay.Heroes.RunEngines {
    #region References

    using UnityEngine;

    #endregion

    internal class RigidbodyRunningEngine : HeroRunningEngine {
        [SerializeField]
        private Rigidbody2D _rigidbody;

        private void FixedUpdate() {
            if (Running) {
                _rigidbody.velocity = new Vector2(Speed, _rigidbody.velocity.y);
            }
        }
    }
}