// Created 23.10.2015 
// Modified by Gorbach Alex 23.10.2015 at 9:27

namespace Assets.Scripts.Engine.Input {
    #region References

    using UnityEngine;

    #endregion

    internal delegate void InputDelegate(Vector2 screenPos);

    internal interface IInputController {
        /// <summary>
        /// Raised when object click detected
        /// </summary>
        event InputDelegate Click;
    }
}