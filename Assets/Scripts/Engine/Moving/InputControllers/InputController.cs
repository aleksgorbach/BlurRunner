// Created 20.10.2015 
// Modified by Gorbach Alex 22.10.2015 at 15:53

namespace Assets.Scripts.Engine.Moving.InputControllers {
    #region References

    using System;
    using UnityEngine;

    #endregion

    internal abstract class InputController : MonoBehaviourBase {
        private const float MIN_SECONDS_BETWEEN_JUMP = 1;

        [SerializeField]
        private MovingController _movingController;

        private DateTime _lastJumpTime;

        protected abstract bool IsJumping { get; }

        protected virtual bool IsRunning {
            get {
                return true;
            }
        }

        private bool CanJump {
            get {
                return (DateTime.Now - _lastJumpTime).TotalSeconds > MIN_SECONDS_BETWEEN_JUMP;
            }
        }

        protected override void Awake() {
            base.Awake();
            _movingController.Run();
            _lastJumpTime = DateTime.Now;
        }

        private void FixedUpdate() {
            if (IsRunning) {
                _movingController.Run();
            }
            if (IsJumping && CanJump) {
                _movingController.Jump();
                _lastJumpTime = DateTime.Now;
            }
        }
    }
}