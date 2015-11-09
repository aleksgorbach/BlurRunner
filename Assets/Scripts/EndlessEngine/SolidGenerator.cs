// Created 09.11.2015 
// Modified by Gorbach Alex 09.11.2015 at 10:34

namespace Assets.Scripts.EndlessEngine {
    #region References

    using Engine.Extensions;
    using UnityEngine;

    #endregion

    internal abstract class SolidGenerator<T> : HidingItemGenerator<T>
        where T : SolidItem<T> {
        [SerializeField]
        private Transform _container;

        private float _lastAddedEdge = 0;

        private void AddBlock() {
            if (!CanGenerate) {
                return;
            }
            var block = Create();
            block.gameObject.SetActive(true);
            block.transform.SetParent(_container, false);
            block.transform.position = new Vector2(_lastAddedEdge, 0);
            block.transform.SetLocalY(0);
            block.transform.SetLocalZ(0);
            _lastAddedEdge = block.Edge;
            Add(block);
        }

        protected override void FixedUpdate() {
            base.FixedUpdate();
            if (transform.position.x > _lastAddedEdge) {
                AddBlock();
            }
        }
    }
}