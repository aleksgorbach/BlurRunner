// Created 30.10.2015 
// Modified by Gorbach Alex 06.11.2015 at 14:09

namespace Assets.Scripts.EndlessEngine {
    #region References

    using System.Collections.Generic;
    using System.Linq;
    using Engine;
    using Engine.Pool;
    using Interfaces;
    using UnityEngine;
    using Zenject;

    #endregion

    internal abstract class HidingItemGenerator<TItem> : AbstractGenerator
        where TItem : MonoBehaviourBase, IHiding {
        private List<Item> _items;

        [SerializeField]
        private float _parallaxDegree = .001f;

        [Inject]
        private IObjectPool<TItem> _pool;

        [Inject]
        private Camera _camera;

        private float _cameraPrevPos;

        protected override void Awake() {
            base.Awake();
            _items = new List<Item>();
        }

        protected void Add(TItem item) {
            var layer = item.transform.localPosition.z / 100;
            Debug.Log(layer);
            _items.Add(new Item(item, layer));
        }

        [PostInject]
        private void PostInject() {
            _cameraPrevPos = _camera.transform.position.x;
            //BottomScreenEdge = _camera.ScreenToWorldPoint(Vector3.zero).y;
        }

        protected TItem Create() {
            RemoveInvisibleItems();
            var block = _pool.Get();
            return block;
        }

        private void RemoveInvisibleItems() {
            var itemsToRemove = _items.Where(x => !x.Obj.IsVisible).ToList();
            foreach (var item in itemsToRemove) {
                Remove(item.Obj);
                OnRemove(item.Obj);
            }
        }

        // Параллакс
        private void FixedUpdate() {
            var cameraPos = _camera.transform.position.x;
            var delta = cameraPos - _cameraPrevPos;
            _cameraPrevPos = cameraPos;
            foreach (var item in _items) {
                item.Obj.transform.Translate(-item.Layer * delta * _parallaxDegree, 0, 0);
            }
        }

        protected void Remove(TItem item) {
            var itemToRemove = _items.FirstOrDefault(x => x.Obj == item);
            _items.Remove(itemToRemove);
            _pool.Release(item);
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