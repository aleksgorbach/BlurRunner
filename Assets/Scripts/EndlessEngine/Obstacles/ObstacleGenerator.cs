// Created 20.11.2015
// Modified by  20.11.2015 at 14:22

namespace Assets.Scripts.EndlessEngine.Obstacles {
    #region References

    using Engine.Extensions;
    using Engine.Pool;
    using Strategy;
    using UnityEngine;

    #endregion

    internal class ObstacleGenerator : HidingItemGenerator<Obstacle> {
        [SerializeField]
        private Transform _container;

        [SerializeField]
        private ObstaclePool _pool;

        [SerializeField]
        private AbstractStrategy _strategy;

        protected override GameObjectPool<Obstacle> Pool {
            get { return _pool; }
        }

        private void Add() {
            if (!CanGenerate) {
                return;
            }
            var created = Create();
            created.gameObject.SetActive(true);
            created.transform.SetParent(_container, false);
            created.transform.position = transform.position;
            created.transform.SetLocalZ(0);
            Add(created);
        }


        protected override void Awake() {
            base.Awake();
            _strategy.NeedGenerate += Add;
        }
    }
}