// Created 23.10.2015 
// Modified by Gorbach Alex 03.11.2015 at 12:34

namespace Assets.Scripts.Engine.Input {
    #region References

    using System;
    using UnityEngine;

    #endregion

    internal delegate void InputDelegate(Vector2 screenPos);

    internal interface IInputController {
        /// <summary>
        /// Raised when click detected
        /// </summary>
        event InputDelegate Click;

        /// <summary>
        /// Raised when dragged screen to left
        /// </summary>
        event Action DragLeft;

        /// <summary>
        /// Raised when dragged screen to right
        /// </summary>
        event Action DragRight;
    }
}