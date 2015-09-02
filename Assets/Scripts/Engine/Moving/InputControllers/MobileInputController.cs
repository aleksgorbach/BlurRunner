using UnityEngine;

namespace Assets.Scripts.Engine.Moving.InputControllers {
    internal class MobileInputController : InputController {
        private bool _touched = false;

        protected override bool IsJumping {
            get {
                var touches = Input.touchCount;
                if (_touched && touches == 0) {
                    _touched = false;
                }
                else if (!_touched && touches > 0) {
                    _touched = true;
                    return true;
                }
                return false;
            }
        }
    }
}