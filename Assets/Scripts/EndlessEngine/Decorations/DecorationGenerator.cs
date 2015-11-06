// Created 03.11.2015 
// Modified by Gorbach Alex 06.11.2015 at 14:33

namespace Assets.Scripts.EndlessEngine.Decorations {
    #region References

    using Strategy;
    using Engine.Extensions;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class DecorationGenerator : HidingItemGenerator<DecorationItem>, IDecorationGenerator {
        [SerializeField]
        private Transform _container;

        [Inject]
        private IGeneratingStrategy _strategy;

        private void Add() {
            if (!CanGenerate) {
                return;
            }
            var created = Create();
            created.gameObject.SetActive(true);
            created.transform.SetParent(_container, false);
            //var dir = (block.TreeContainer.position - _camera.transform.position);
            //created.transform.position = _camera.transform.position + dir/dir.z*Random.Range(600, 850);
            var distanceToCreated = Random.Range(5, 100);
            created.transform.position = transform.position;
            created.transform.SetLocalZ(distanceToCreated);
            Add(created);
        }

        [PostInject]
        private void PostInject() {
            _strategy.NeedGenerate += Add;
        }
    }
}