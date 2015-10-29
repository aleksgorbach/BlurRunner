// Created 29.10.2015
// Modified by Александр 29.10.2015 at 21:21

namespace Assets.Scripts.Gameplay.Heroes {
    #region References

    using System;
    using Engine;
    using UnityEngine;

    #endregion

    internal delegate void CollidedDelegate();

    [RequireComponent(typeof (Collider2D))]
    internal class Stand : MonoBehaviourBase {
        private bool _isGrounded;

        private void OnCollisionEnter2D(Collision2D collision) {
            if (!_isGrounded) {
                _isGrounded = true;
                var handler = Grounded;
                if (handler != null) {
                    handler();
                }
            }
        }

        private void OnCollisionExit2D(Collision2D collision) {
            _isGrounded = false;
        }

        public event Action Grounded;
    }
}