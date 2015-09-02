using System.Collections.Generic;
using Assets.Scripts.EndlessEngine.Ground.Generators;
using Assets.Scripts.Engine.Extensions;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.EndlessEngine.Ground.UI {
    internal class GroundGeneratorUI : MonoBehaviour {
        private Queue<GroundBlockUI> _blocks;
        [Inject] private IGroundGenerator _generator;

        private GroundBlockUI _lastAddedBlock;

        private float _length;
        private float _cameraWidth;

        private void Add() {
            var block = GenerateBlock(_lastAddedBlock);
            var rectTransform = block.GetComponent<RectTransform>();
            rectTransform.SetParent(transform, false);
            rectTransform.anchoredPosition3D = new Vector2(_lastAddedBlock != null ? _lastAddedBlock.Edge : 0, 0);
            _blocks.Enqueue(block);
            _lastAddedBlock = block;
            UpdateLength();
        }

        private void AddMissingBlocks() {
            while (_length < _cameraWidth) {
                Add();
            }
        }

        private void Awake() {
            _blocks = new Queue<GroundBlockUI>();
        }

        private GroundBlockUI GenerateBlock(GroundBlockUI leftBlock) {
            var block = _generator.GetCompatibleBlock(leftBlock);
            return block;
        }

        [PostInject]
        private void Init() {
            _cameraWidth = Camera.main.GetWidth(transform.position.z);
            AddMissingBlocks();
        }

        private void RemoveBlock(GroundBlockUI block) {
            _generator.ReturnBlock(block);
            UpdateLength();
        }

        private void Update() {
            if (_blocks.Count == 0) {
                return;
            }
            while (!(_blocks.Peek()).IsVisible) {
                RemoveBlock(_blocks.Dequeue());
                if (_blocks.Count == 0) {
                    break;
                }
            }
            AddMissingBlocks();
        }

        private void UpdateLength() {
            _length = 0;
            foreach (var block in _blocks) {
                _length += block.Length;
            }
        }
    }
}