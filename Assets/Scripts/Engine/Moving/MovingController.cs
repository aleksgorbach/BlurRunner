// Created 20.10.2015 
// Modified by Gorbach Alex 28.10.2015 at 16:32

#region References

using UnityEngine;

#endregion

namespace Assets.Scripts.Engine.Moving {
    #region References

    using Input;
    using Zenject;

    #endregion

    internal class MovingController : MonoBehaviourBase {
        [SerializeField]
        private int _jumpForce;

        [SerializeField]
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private int _runForce;

        private IInputController _controller;

        private Vector2 _jumpVector;
        private Vector2 _runVector;

        protected override void Awake() {
            base.Awake();
            _runVector = Vector2.right * _runForce;
            _jumpVector = Vector2.up * _jumpForce;
        }

        [PostInject]
        private void Inject(IInputController inputController) {
            _controller = inputController;
            _controller.Click += OnClick;
        }

        private void FixedUpdate() {
            Run();
        }

        private void OnClick(Vector2 screenpos) {
            Jump();
        }

        private void Run() {
            _rigidbody.velocity = _runVector;
        }

        private void Jump() {
            _rigidbody.AddForce(_jumpVector);
        }
    }
}