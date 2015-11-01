// Created 28.10.2015
// Modified by Александр 01.11.2015 at 12:37

#region References

#endregion

namespace Assets.Scripts.Engine.Moving {
    #region References

    using Input;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class MovingController : MonoBehaviourBase, IMovingController {
        [Inject]
        private IInputController _controller;

        [SerializeField]
        private int _jumpForce;

        [SerializeField]
        private Movable _movable;


        [SerializeField]
        private int _runForce;

        protected override void Start() {
            base.Start();
            _movable.Run(_runForce);
        }

        [PostInject]
        private void PostInject() {
            _controller.Click += OnClick;
        }

        private void OnClick(Vector2 screenpos) {
            _movable.Jump(_jumpForce);
        }
    }
}