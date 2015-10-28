// Created 26.10.2015 
// Modified by Gorbach Alex 28.10.2015 at 9:59

namespace Assets.Scripts.EndlessEngine.Ground.Decorations.UI {
    #region References

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Engine;
    using Ground.UI;
    using UnityEngine;
    using Zenject;
    using Random = UnityEngine.Random;

    #endregion

    internal class DecorationGeneratorUI : MonoBehaviourBase, IDecorationGeneratorUI {
        private Camera _camera;

        [Inject]
        private IDecorationGenerator _generator;

        private List<DecorationItemUI> _items;

        public void Add(DecorationItemUI created, GroundBlockUI block) {
            CheckInvisibleItems();
            created.transform.SetParent(transform, false);
            var dir = (block.TreeContainer.position - _camera.transform.position);
            created.transform.position = _camera.transform.position + dir / dir.z * Random.Range(600, 850);
            _items.Add(created);
        }

        public event Action<DecorationItemUI> ItemHidden;

        private void OnItemHide(DecorationItemUI item) {
            _items.Remove(item);
            var handler = ItemHidden;
            if (handler != null) {
                handler.Invoke(item);
            }
        }

        private void CheckInvisibleItems() {
            var itemsToRemove = _items.Where(x => !x.IsVisible).ToList();
            foreach (var item in itemsToRemove) {
                OnItemHide(item);
            }
        }

        [PostInject]
        private void Inject(Camera mainCamera) {
            _camera = mainCamera;
            _items = new List<DecorationItemUI>();
        }
    }
}