// Created 20.10.2015 
// Modified by Gorbach Alex 22.10.2015 at 15:57

#region References

using UnityEngine;

#endregion

namespace Assets.Scripts.Engine.Moving {
    internal class MovingController : MonoBehaviourBase {
        [SerializeField]
        private int _jumpForce;

        private Vector2 _jumpVector;

        [SerializeField]
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private int _runForce;

        private Vector2 _runVector;

        protected override void Awake() {
            base.Awake();
            _runVector = Vector2.right * _runForce;
            _jumpVector = Vector2.up * _jumpForce;
        }

        public void Run() {
            _rigidbody.velocity = _runVector;
        }

        public void Jump() {
            _rigidbody.AddForce(_jumpVector);
        }
    }
}