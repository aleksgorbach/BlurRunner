﻿// Created 20.10.2015
// Modified by  30.11.2015 at 15:04

namespace Assets.Scripts.Engine {
    #region References

    using UnityEngine;

    #endregion

    internal class ObjectAnchor : MonoBehaviourBase {
        [SerializeField]
        private Transform _anchoredObject;

        private Vector3 _initialPos;
        private float _velocity;

        [SerializeField]
        private bool _xAnchor;

        [SerializeField]
        private bool _yAnchor;

        protected override void Awake() {
            base.Awake();
            _initialPos = transform.position;
        }

        protected override void Update() {
            base.Update();
            if (_anchoredObject == null) {
                return;
            }
            //var pos = Mathf.SmoothDamp(transform.position.x, _anchoredObject.position.x, ref _velocity, Time.deltaTime);
            transform.position = new Vector3(
                _xAnchor ? _anchoredObject.position.x : _initialPos.x,
                _yAnchor ? _anchoredObject.position.y : _initialPos.y,
                _initialPos.z);
        }

        public void SetTarget(Transform transf) {
            _anchoredObject = transf;
        }
    }
}