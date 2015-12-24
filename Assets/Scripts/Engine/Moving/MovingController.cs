// Created 20.10.2015
// Modified by  24.12.2015 at 9:26

#region References

#endregion

namespace Assets.Scripts.Engine.Moving {
    #region References

    using System.Collections.Generic;
    using Input;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class MovingController : MonoBehaviourBase, IMovingController {
        #region Visible in inspector

        [SerializeField]
        private int _runForce;

        [SerializeField]
        private int _jumpForce;

        #endregion

        [Inject]
        private IInputController _controller;

        private List<IMovable> _movables;


        public void RegisterMovable(IMovable movable) {
            _movables.Add(movable);
        }

        protected override void Awake() {
            base.Awake();
            _movables = new List<IMovable>();
        }

        protected override void Start() {
            base.Start();
            foreach (var movable in _movables) {
                movable.Run(_runForce);
            }
        }

        [PostInject]
        private void PostInject() {
            _controller.Click += OnClick;
        }

        private void OnClick(Vector2 screenpos) {
            foreach (var movable in _movables) {
                movable.Jump(_jumpForce);
            }
        }
    }
}