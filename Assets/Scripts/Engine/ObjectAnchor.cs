// Created 20.10.2015 
// Modified by Gorbach Alex 22.10.2015 at 15:58

namespace Assets.Scripts.Engine {
    #region References

    using UnityEngine;

    #endregion

    internal class ObjectAnchor : MonoBehaviourBase {
        [SerializeField]
        private Transform _anchoredObject;

        [SerializeField]
        private bool _xAnchor;

        [SerializeField]
        private bool _yAnchor;

        private Vector3 _initialPos;
        private Transform _transform;

        protected override void Awake() {
            base.Awake();
            _initialPos = transform.position;
            _transform = transform;
        }

        protected override void Update() {
            base.Update();
            _transform.position = new Vector3(
                _xAnchor ? _anchoredObject.position.x : _initialPos.x,
                _yAnchor ? _anchoredObject.position.y : _initialPos.y,
                _initialPos.z);
        }
    }
}