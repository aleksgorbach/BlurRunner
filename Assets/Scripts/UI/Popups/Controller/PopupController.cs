// Created 23.10.2015
// Modified by  28.01.2016 at 12:40

namespace Assets.Scripts.UI.Popups.Controller {
    #region References

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Engine;
    using Factory;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class PopupController : MonoBehaviourBase, IPopupController {
        #region Injected dependencies

        [Inject]
        private PopupFactory _factory;

        #endregion

        #region Interface

        public event EventHandler<PopupEventArgs> PopupOpened;
        public event EventHandler<PopupEventArgs> PopupClosed;

        public void Close() {
            var popup = _popups.Peek();
            if (popup != null) {
                popup.Close();
            }
        }

        #endregion

        private Stack<Popup> _popups;


        public IPopup Show<TPopup>() where TPopup : Popup {
            var popup = _factory.Create<TPopup>();
            StartCoroutine(PopupShowingCoroutine(popup));
            return popup;
        }

        private IEnumerator PopupShowingCoroutine(Popup popup) {
            yield return new WaitForSeconds(popup.Delay);
            popup.gameObject.SetActive(true);
            popup.transform.SetParent(transform);
            popup.rectTransform.anchoredPosition = Vector2.zero;
            popup.rectTransform.offsetMax = Vector2.zero;
            popup.rectTransform.offsetMin = Vector2.zero;
            popup.rectTransform.localScale = Vector3.one;
            _popups.Push(popup);
            Subscribe(popup);
            OnPopupOpened(popup);
        }

        private void Subscribe(IPopup popup) {
            popup.Closed += OnClose;
        }

        private void Unsubscribe(IPopup popup) {
            popup.Closed -= OnClose;
        }

        private void OnClose(Popup popup) {
            if (_popups.Count > 0) {
                var top = _popups.Pop();
                Unsubscribe(top);
                Destroy(popup.gameObject);
                OnPopupClosed(popup);
            }
        }

        protected override void Awake() {
            base.Awake();
            _popups = new Stack<Popup>();
        }

        private void OnPopupOpened(IPopup popup) {
            var handler = PopupOpened;
            if (handler != null) {
                handler.Invoke(this, new PopupEventArgs(popup, _popups.Count));
            }
        }

        private void OnPopupClosed(IPopup popup) {
            var handler = PopupClosed;
            if (handler != null) {
                handler.Invoke(this, new PopupEventArgs(popup, _popups.Count));
            }
        }
    }
}