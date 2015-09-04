using System;
using UnityEngine;

namespace Assets.Scripts.Engine.Moving.InputControllers {
    internal abstract class InputController : MonoBehaviour {
        private const float MIN_SECONDS_BETWEEN_JUMP = 1;
        [SerializeField] private MovingController _movingController;
        private DateTime _lastJumpTime;

        private void Awake() {
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

        protected abstract bool IsJumping { get; }

        protected virtual bool IsRunning {
            get { return true; }
        }

        private bool CanJump {
            get { return (DateTime.Now - _lastJumpTime).TotalSeconds > MIN_SECONDS_BETWEEN_JUMP; }
        }
    }
}