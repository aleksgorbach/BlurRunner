// Created 28.10.2015
// Modified by Александр 29.10.2015 at 21:05

#region References

#endregion

namespace Assets.Scripts.Engine.Moving {
    #region References

    using Input;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class MovingController : MonoBehaviourBase, IMovingController {
        private IInputController _controller;

        [SerializeField]
        private int _jumpForce;

        private IMovable _movable;


        [SerializeField]
        private int _runForce;


        public void Add(IMovable movable) {
            _movable = movable;
            _movable.Run(_runForce);
        }

        [PostInject]
        private void Inject(IInputController inputController) {
            _controller = inputController;
            _controller.Click += OnClick;
        }

        private void OnClick(Vector2 screenpos) {
            _movable.Jump(_jumpForce);
        }
    }
}