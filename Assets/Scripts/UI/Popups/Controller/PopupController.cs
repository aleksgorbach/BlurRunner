// Created 22.10.2015
// Modified by Александр 22.10.2015 at 22:00

namespace Assets.Scripts.UI.Popups.Controller {
    #region References

    using System.Collections.Generic;
    using Engine;
    using Factory;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class PopupController : MonoBehaviourBase, IPopupController {
        private PopupPool _pool;
        private Stack<Popup> _popups;

        public IPopup Show<TPopup>() where TPopup : Popup {
            var popup = _pool.Get<TPopup>();
            popup.transform.SetParent(transform);
            popup.rectTransform.anchoredPosition = Vector2.zero;
            popup.rectTransform.offsetMax = Vector2.zero;
            popup.rectTransform.offsetMin = Vector2.zero;
            _popups.Push(popup);
            return popup;
        }

        public void Close() {
            if (_popups.Count > 0) {
                var popup = _popups.Pop();
                _pool.Release(popup);
            }
        }

        protected override void Awake() {
            base.Awake();
            _popups = new Stack<Popup>();
        }

        [PostInject]
        private void Init(PopupPool pool) {
            _pool = pool;
        }
    }
}