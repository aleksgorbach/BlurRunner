// Created 23.10.2015 
// Modified by Gorbach Alex 03.11.2015 at 13:19

namespace Assets.Scripts.Engine.Input {
    #region References

    using System;
    using UnityEngine;

    #endregion

    internal class InputController : MonoBehaviourBase, IInputController {
        [SerializeField]
        [Tooltip("Max offset when drag at concrete direction is not detected")]
        private float _dragMaxOffset;

        [SerializeField]
        private float _dragThreshold;

        private Vector3 _dragBeginPosition;

        public event InputDelegate Click;
        public event Action DragLeft;
        public event Action DragRight;

        public void OnClick() {
            var handler = Click;
            if (handler != null) {
                handler.Invoke(Vector2.zero);
            }
        }

        public void OnBeginDrag() {
            _dragBeginPosition = Input.mousePosition;
        }

        public void OnEndDrag() {
            var diff = Input.mousePosition - _dragBeginPosition;
            if (Mathf.Abs(diff.x) >= _dragThreshold && Mathf.Abs(diff.y) < _dragMaxOffset) {
                if (diff.x < 0) {
                    OnDragLeft();
                }
                else {
                    OnDragRight();
                }
            }
        }

        private void OnDragLeft() {
            var handler = DragLeft;
            if (handler != null) {
                handler.Invoke();
            }
        }

        private void OnDragRight() {
            var handler = DragRight;
            if (handler != null) {
                handler.Invoke();
            }
        }
    }
}