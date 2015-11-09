// Created 09.11.2015 
// Modified by Gorbach Alex 09.11.2015 at 9:08

namespace Assets.Scripts.EndlessEngine {
    #region References

    using System.Collections.Generic;
    using System.Linq;
    using Engine.Pool;
    using UnityEngine;
    using Zenject;

    #endregion

    internal abstract class HidingItemGenerator<TItem> : AbstractGenerator
        where TItem : HidingItem<TItem> {
        protected float _cameraWidth;
        protected List<Item> _items;

        [SerializeField]
        private readonly float _parallaxDegree = .001f;

        [Inject]
        private Camera _camera;

        private float _cameraPrevPos;

        protected abstract GameObjectPool<TItem> Pool { get; }

        protected override void Awake() {
            base.Awake();
            _items = new List<Item>();
        }

        protected void Add(TItem item) {
            item.NeedRemove += Remove;
            var layer = item.transform.localPosition.z / 100;
            _items.Add(new Item(item, layer));
        }

        [PostInject]
        private void PostInject() {
            _cameraPrevPos = _camera.transform.position.x;
            _cameraWidth = _camera.aspect * 2 * _camera.orthographicSize;
        }

        protected TItem Create() {
            var block = Pool.Get();
            return block;
        }

        // Параллакс
        protected virtual void FixedUpdate() {
            var cameraPos = _camera.transform.position.x;
            var delta = cameraPos - _cameraPrevPos;
            _cameraPrevPos = cameraPos;
            foreach (var item in _items) {
                item.Obj.transform.Translate(-item.Layer * delta * _parallaxDegree, 0, 0);
            }
        }

        protected void Remove(TItem item) {
            var itemToRemove = _items.FirstOrDefault(x => x.Obj == (TItem)item);
            _items.Remove(itemToRemove);
            item.NeedRemove -= Remove;
            OnRemove(item);
            Pool.Release(item);
        }

        protected virtual void OnRemove(TItem item) {
        }

        protected class Item {
            public Item(TItem item, float layer) {
                Obj = item;
                Layer = layer;
            }

            public TItem Obj { get; private set; }
            public float Layer { get; private set; }
        }
    }
}