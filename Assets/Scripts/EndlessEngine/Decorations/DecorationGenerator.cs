// Created 02.11.2015
// Modified by Александр 02.11.2015 at 20:20

namespace Assets.Scripts.EndlessEngine.Decorations {
    #region References

    using Ground;
    using Ground.UI;
    using Strategy;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class DecorationGenerator : HidingItemGenerator<DecorationItem>, IDecorationGenerator {
        [Inject]
        private Camera _camera;

        [Inject]
        private IGroundGenerator _groundGenerator;

        [Inject]
        private IGeneratingStrategy _strategy;

        private void Add(GroundBlock block) {
            var created = Create();
            created.gameObject.SetActive(true);
            created.transform.SetParent(transform, false);
            var dir = (block.TreeContainer.position - _camera.transform.position);
            created.transform.position = _camera.transform.position + dir/dir.z*Random.Range(600, 850);
            _items.Add(created);
        }


        [PostInject]
        private void PostInject() {
            _groundGenerator.BlockCreated += OnBlockCreated;
        }

        private void OnBlockCreated(GroundBlock block) {
            if (_strategy.IsGeneratingNeeded) {
                Add(block);
            }
        }
    }
}