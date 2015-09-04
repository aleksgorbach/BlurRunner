using System.Collections.Generic;
using Assets.Scripts.EndlessEngine.Ground.Generators;
using Assets.Scripts.Engine.Extensions;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.EndlessEngine.Ground.UI {
    internal class GroundGeneratorUI : MonoBehaviour {
        [SerializeField] private GameObject[] _treePrefabs;
        private Queue<GroundBlockUI> _blocks;
        private float _cameraWidth;
        private Camera _camera;
        [Inject] private IGroundGenerator _generator;
        private GroundBlockUI _lastAddedBlock;
        private float _length;

        private void Add() {
            var block = GenerateBlock(_lastAddedBlock);
            var rectTransform = block.GetComponent<RectTransform>();
            rectTransform.SetParent(transform, false);
            rectTransform.anchoredPosition3D = new Vector2(_lastAddedBlock != null ? _lastAddedBlock.Edge : 0, 0);
            _blocks.Enqueue(block);
            _lastAddedBlock = block;
            UpdateLength();
            GenerateStuff(block);
        }

        private void GenerateStuff(GroundBlockUI block) {
            if (block.TreeContainer.childCount > 0) {
                return;
            }
            if (Random.Range(0, 2) == 0) {
                return;
            }

            var tree = Instantiate(_treePrefabs.Random());
            tree.transform.SetParent(block.TreeContainer);
            var origin = _camera.transform.position;
            var direction = (block.transform.position - origin);
            var point = new Ray(origin, direction).GetPoint(Random.Range(100, 300));
            tree.transform.localPosition = new Vector3(0, point.y, point.z);
        }

        private void AddMissingBlocks() {
            while (_length < _cameraWidth*1.2f) {
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
            _camera = Camera.main;
            _cameraWidth = _camera.GetWidth(transform.position.z);
            AddMissingBlocks();
        }

        private void RemoveBlock(GroundBlockUI block) {
            _generator.ReturnBlock(block);
            UpdateLength();
        }

        private void FixedUpdate() {
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