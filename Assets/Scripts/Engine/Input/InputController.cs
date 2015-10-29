// Created 24.10.2015
// Modified by Александр 29.10.2015 at 20:30

namespace Assets.Scripts.Engine.Input {
    #region References

    using UnityEngine;

    #endregion

    internal class InputController : MonoBehaviourBase, IInputController {
        public event InputDelegate Click;


        public void OnClick() {
            var handler = Click;
            if (handler != null) {
                handler.Invoke(Vector2.zero);
            }
        }
    }
}