// Created 23.10.2015 
// Modified by Gorbach Alex 23.10.2015 at 10:17

namespace Assets.Scripts.Engine.Input {
    #region References

    using UnityEngine;

    #endregion

    internal class InputController : MonoBehaviourBase, IInputController {
        //private const float MIN_SECONDS_BETWEEN_JUMP = 1;

        //[SerializeField]
        //private MovingController _movingController;

        //private DateTime _lastJumpTime;

        //protected abstract bool IsJumping { get; }

        //protected virtual bool IsRunning {
        //    get {
        //        return true;
        //    }
        //}

        //private bool CanJump {
        //    get {
        //        return (DateTime.Now - _lastJumpTime).TotalSeconds > MIN_SECONDS_BETWEEN_JUMP;
        //    }
        //}

        public event InputDelegate Click;

        //protected override void Awake() {
        //    base.Awake();
        //    _movingController.Run();
        //    _lastJumpTime = DateTime.Now;
        //}

        //private void FixedUpdate() {
        //    if (IsRunning) {
        //        _movingController.Run();
        //    }
        //    if (IsJumping && CanJump) {
        //        _movingController.Jump();
        //        _lastJumpTime = DateTime.Now;
        //    }
        //}

        public void OnClick() {
            var handler = Click;
            if (handler != null) {
                handler.Invoke(Vector2.zero);
            }
        }
    }
}