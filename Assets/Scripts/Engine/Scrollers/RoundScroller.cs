// Created 01.11.2015
// Modified by Александр 01.11.2015 at 19:27

namespace Assets.Scripts.Engine.Scrollers {
    #region References

    using System.Collections.Generic;
    using UnityEngine;

    #endregion

    internal class RoundScroller : MonoBehaviourBase {
        private LinkedListNode<IScrollerItem> _current;
        private LinkedList<IScrollerItem> _items;

        [SerializeField]
        private float _radius;

        protected override void Awake() {
            base.Awake();
            _items = new LinkedList<IScrollerItem>();
        }

        public void AddItem(IScrollerItem item) {
            item.Transform.SetParent(transform, false);
            _items.AddFirst(item);
            _current = _items.First;
        }

        private void ScrollNext() {
            var next = _current.Next ?? _items.First;
        }

        private void ScrollPrevious() {
            var prev = _current.Previous ?? _items.Last;
        }
    }
}