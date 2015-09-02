using UnityEngine;

namespace Assets.Scripts.Engine.Moving.InputControllers {
    internal abstract class InputController : MonoBehaviour {
        [SerializeField] private MovingController _movingController;

        private void Awake() {
            _movingController.Run();
        }

        private void FixedUpdate() {
            if (IsRunning) {
                _movingController.Run();
            }
            if (IsJumping) {
                _movingController.Jump();
            }
        }

        protected abstract bool IsJumping { get; }

        protected virtual bool IsRunning {
            get { return true; }
        }
    }
}