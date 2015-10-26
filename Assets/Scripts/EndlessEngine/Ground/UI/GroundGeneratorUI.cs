﻿// Created 20.10.2015 
// Modified by Gorbach Alex 26.10.2015 at 11:20

#region References

#endregion

namespace Assets.Scripts.EndlessEngine.Ground.UI {
    #region References

    using System.Collections.Generic;
    using Engine;
    using Engine.Extensions;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class GroundGeneratorUI : MonoBehaviourBase, IGroundGeneratorUI {
        private Queue<GroundBlockUI> _blocks;
        private Camera _camera;
        private float _cameraWidth;

        private GroundBlockUI _lastAddedBlock;
        private float _length;

        public event BlockEventDelegate NewBlockNeed;
        public event BlockEventDelegate RemoveBlockNeeded;

        public void AddBlock(GroundBlockUI block) {
            block.rectTransform.SetParent(transform, false);
            block.rectTransform.anchoredPosition3D = new Vector2(_lastAddedBlock != null ? _lastAddedBlock.Edge : 0, 0);
            _blocks.Enqueue(block);
            _lastAddedBlock = block;
            UpdateLength();
        }

        public void RemoveBlock() {
            _blocks.Dequeue();
            UpdateLength();
        }

        [PostInject]
        private void Inject(IGroundGenerator generator) {
            AddMissingBlock();
        }

        private void AddMissingBlock() {
            if (_length < _cameraWidth * 1.2f) {
                OnNewBlockNeeded(_lastAddedBlock);
            }
        }

        protected override void Awake() {
            base.Awake();
            _blocks = new Queue<GroundBlockUI>();
            _camera = Camera.main;
            _cameraWidth = _camera.GetWidth(transform.position.z);
        }

        private void FixedUpdate() {
            if (_blocks.Count == 0) {
                return;
            }
            var block = _blocks.Peek();
            while (!block.IsVisible) {
                OnRemoveBlockNeeded(block);
                if (_blocks.Count == 0) {
                    break;
                }
                block = _blocks.Peek();
            }
            AddMissingBlock();
        }

        private void UpdateLength() {
            _length = 0;
            foreach (var block in _blocks) {
                _length += block.Length;
            }
            AddMissingBlock();
        }

        private void OnNewBlockNeeded(GroundBlockUI rightBlock) {
            var handler = NewBlockNeed;
            if (handler != null) {
                handler.Invoke(rightBlock);
            }
        }

        private void OnRemoveBlockNeeded(GroundBlockUI block) {
            var handler = RemoveBlockNeeded;
            if (handler != null) {
                handler.Invoke(block);
            }
        }
    }
}