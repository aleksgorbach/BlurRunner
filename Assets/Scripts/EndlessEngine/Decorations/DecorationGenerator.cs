// Created 03.11.2015
// Modified by  20.11.2015 at 12:41

namespace Assets.Scripts.EndlessEngine.Decorations {
    #region References

    using Engine.Extensions;
    using Engine.Pool;
    using Strategy;
    using UnityEngine;

    #endregion

    internal class DecorationGenerator : HidingItemGenerator<DecorationItem>, IDecorationGenerator {
        [SerializeField]
        private Transform _container;

        [SerializeField]
        private float _maxDistance;

        [SerializeField]
        private float _minDistance;

        [SerializeField]
        private DecorationPool _pool;

        [SerializeField]
        private AbstractStrategy _strategy;

        protected override GameObjectPool<DecorationItem> Pool {
            get { return _pool; }
        }

        private void Add() {
            if (!CanGenerate) {
                return;
            }
            var created = Create();
            created.gameObject.SetActive(true);
            created.transform.SetParent(_container, false);
            //var dir = (block.TreeContainer.position - _camera.transform.position);
            //created.transform.position = _camera.transform.position + dir/dir.z*Random.Range(600, 850);
            var distanceToCreated = Random.Range(_minDistance, _maxDistance);
            created.transform.position = transform.position;
            created.transform.SetLocalZ(distanceToCreated);
            Add(created);
        }


        protected override void Awake() {
            base.Awake();
            _strategy.NeedGenerate += Add;
        }
    }
}