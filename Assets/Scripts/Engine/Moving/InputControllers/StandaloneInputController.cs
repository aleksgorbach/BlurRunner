using UnityEngine;

namespace Assets.Scripts.Engine.Moving.InputControllers {
    internal class StandaloneInputController : InputController {
        protected override bool IsJumping {
            get { return Input.GetMouseButtonDown(0); }
        }
    }
}