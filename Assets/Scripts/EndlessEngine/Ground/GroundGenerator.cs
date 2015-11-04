// Created 26.10.2015 
// Modified by Gorbach Alex 04.11.2015 at 13:34

#region References

#endregion

namespace Assets.Scripts.EndlessEngine.Ground {
    #region References

    using System.Collections.Generic;
    using Assets.Scripts.Engine.Factory.Strategy;
    using Engine;
    using Engine.Extensions;
    using Engine.Pool;
    using UI;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class GroundGenerator : MonoBehaviourBase, IGroundGenerator {
        private Queue<GroundBlock> _blocks;
        private Camera _camera;
        private float _cameraWidth;

        private GroundBlock _lastAddedBlock;
        private float _length;

        [Inject]
        private IObjectPool<GroundBlock> _pool;

        public event BlockEventDelegate BlockCreated;
        public event BlockEventDelegate BlockRemoved;

        private void AddBlock() {
            var block = _pool.Get();
            block.gameObject.SetActive(true);
            block.rectTransform.SetParent(transform, false);
            block.rectTransform.anchoredPosition3D = new Vector2(_lastAddedBlock != null ? _lastAddedBlock.Edge : 0, 0);
            _blocks.Enqueue(block);
            _lastAddedBlock = block;
            OnBlockCreated(block);
            UpdateLength();
        }

        private void RemoveBlock() {
            var block = _blocks.Dequeue();
            _pool.Release(block);
            OnBlockRemoved(block);
            UpdateLength();
        }

        [PostInject]
        private void PostInject() {
            AddMissingBlock();
        }

        private void AddMissingBlock() {
            if (_length < _cameraWidth * 1.2f) {
                AddBlock();
            }
        }

        protected override void Awake() {
            base.Awake();
            _blocks = new Queue<GroundBlock>();
            _camera = Camera.main;
            _cameraWidth = _camera.GetWidth(transform.position.z);
        }

        private void FixedUpdate() {
            if (_blocks.Count == 0) {
                return;
            }
            var block = _blocks.Peek();
            while (!block.IsVisible) {
                RemoveBlock();
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

        private void OnBlockCreated(GroundBlock block) {
            var handler = BlockCreated;
            if (handler != null) {
                handler.Invoke(block);
            }
        }

        private void OnBlockRemoved(GroundBlock block) {
            var handler = BlockRemoved;
            if (handler != null) {
                handler.Invoke(block);
            }
        }
    }
}