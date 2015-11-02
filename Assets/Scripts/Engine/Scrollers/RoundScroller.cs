// Created 02.11.2015 
// Modified by Gorbach Alex 02.11.2015 at 15:32

namespace Assets.Scripts.Engine.Scrollers {
    #region References

    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Assets.Scripts.Engine.Extensions;
    using DG.Tweening;
    using UnityEngine;

    #endregion

    internal class RoundScroller : MonoBehaviourBase {
        private float ANGLE = 45;

        [SerializeField]
        private float _rotationTime;

        private LinkedListNode<IScrollerItem> _current;
        private LinkedList<IScrollerItem> _items;

        [SerializeField]
        private float _radius;

        [SerializeField]
        private int _visibleCount = 3;

        protected override void Awake() {
            base.Awake();
            _items = new LinkedList<IScrollerItem>();
        }

        public void AddItem(IScrollerItem item) {
            item.Transform.SetParent(transform, false);
            _items.AddFirst(item);
            _current = _items.First;
            SituateItems();
        }

        private void SituateItems() {
            ANGLE = 360f / _items.Count;
            var current = _items.First;
            var angle = 0f;
            while (current != null) {
                current.Value.Transform.anchoredPosition = GetPositionAtAngle(angle);
                current = current.Next;
                angle += ANGLE;
            }
        }

        private Vector2 GetPositionAtAngle(float angleDegrees) {
            return new Vector2(
                _radius * Mathf.Sin(angleDegrees * Mathf.Deg2Rad),
                _radius * Mathf.Cos(angleDegrees * Mathf.Deg2Rad));
        }

        public void ScrollNext() {
            //var items = new List<RotatingItem> {
            //                                       new RotatingItem(-ANGLE, _current.Value),
            //                                       new RotatingItem(0, _current.PreviousOrLast().Value),
            //                                       new RotatingItem(
            //                                           ANGLE,
            //                                           _current.PreviousOrLast().PreviousOrLast().Value)
            //                                   };
            Animate();
            _current = _current.NextOrFirst();
        }

        private void ScrollPrevious() {
            var prev = _current.Previous ?? _items.Last;
        }

        private void Animate() {
            //var time = 0f;
            //while (time < _rotationTime) {
            //    var curTime = time / _rotationTime;
            //    foreach (var item in items) {
            //        var curAngle = Mathf.Lerp(item.StartAngle, item.EndAngle, curTime);
            //        item.Item.Transform.anchoredPosition = GetPositionAtAngle(curAngle);
            //    }
            //    time += Time.deltaTime;
            //    yield return null;
            //}
            transform.DORotate(new Vector3(0, 0, transform.rotation.z + ANGLE), _rotationTime);
        }

        private class RotatingItem {
            public readonly IScrollerItem Item;
            public readonly float StartAngle;
            public readonly float EndAngle;

            public RotatingItem(float to, IScrollerItem item) {
                Item = item;
                var itemPos = item.Transform.anchoredPosition;
                StartAngle = Mathf.Atan2(itemPos.x, itemPos.y) * Mathf.Rad2Deg;
                Debug.Log(StartAngle + ": " + to);
                EndAngle = to;
            }
        }
    }
}