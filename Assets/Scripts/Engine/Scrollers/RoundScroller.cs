// Created 02.11.2015 
// Modified by Gorbach Alex 03.11.2015 at 14:53

namespace Assets.Scripts.Engine.Scrollers {
    #region References

    using System;
    using System.Collections.Generic;
    using DG.Tweening;
    using UnityEngine;

    #endregion

    internal class RoundScroller : MonoBehaviourBase, IRoundScroller {
        private readonly List<IScrollerItem> _items = new List<IScrollerItem>();
        private float _angle;

        [SerializeField]
        private float _rotationTime;

        private int _current = 0;

        [SerializeField]
        private float _radius;

        public IScrollerItem Current {
            get {
                return _items[_current];
            }
        }

        public void AddItem(IScrollerItem item) {
            item.Transform.SetParent(transform, false);
            _items.Add(item);
            SituateItems();
            OnCurrentChanged(_items[_current]);
        }

        public void ScrollNext() {
            int nextIndex;
            if (_current < _items.Count - 1) {
                nextIndex = _current + 1;
            }
            else {
                nextIndex = 0;
            }
            Animate(_current, nextIndex, _angle);
            _current = nextIndex;
            OnCurrentChanged(_items[_current]);
        }

        public void ScrollPrevious() {
            int nextIndex;
            if (_current > 0) {
                nextIndex = _current - 1;
            }
            else {
                nextIndex = _items.Count - 1;
            }
            Animate(_current, nextIndex, -_angle);
            _current = nextIndex;
            OnCurrentChanged(_items[_current]);
        }

        public event Action<IScrollerItem> CurrentChanged;

        private void OnCurrentChanged(IScrollerItem current) {
            var handler = CurrentChanged;
            if (handler != null) {
                handler.Invoke(current);
            }
        }

        private void SituateItems() {
            _angle = 360f / _items.Count;
            var angle = 0f;
            for (var i = 0; i < _items.Count; i++) {
                _items[i].Transform.anchoredPosition = GetPositionAtAngle(angle);
                angle += _angle;
            }
        }

        private Vector2 GetPositionAtAngle(float angleDegrees) {
            return new Vector2(
                _radius * Mathf.Sin(angleDegrees * Mathf.Deg2Rad),
                _radius * Mathf.Cos(angleDegrees * Mathf.Deg2Rad));
        }

        private void Animate(int currentIndex, int nextIndex, float angle) {
            _items[currentIndex].Transform.DOScale(Vector3.one, _rotationTime);
            _items[nextIndex].Transform.DOScale(new Vector3(1.3f, 1.3f, 1), _rotationTime);
            transform.DORotate(new Vector3(0, 0, angle), _rotationTime, RotateMode.LocalAxisAdd)
                .OnUpdate(LookItemsUpward);
        }

        private void LookItemsUpward() {
            foreach (var item in _items) {
                item.Transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
}