// Created 23.10.2015
// Modified by  24.12.2015 at 12:57

namespace Assets.Scripts.UI.Popups.Controller {
    #region References

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Engine;
    using Factory;
    using Gameplay.Consts;
    using Gameplay.GameState.Manager;
    using Implementations;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class PopupController : MonoBehaviourBase, IPopupController {
        [Inject]
        private PopupFactory _factory;

        private Stack<Popup> _popups;

        [Inject]
        private IGameStateManager _stateManager;

        public event Action<IPopup, int> PopupOpened;
        public event Action<IPopup, int> PopupClosed;

        private IPopup Show<TPopup>() where TPopup : Popup {
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

        private void Subscribe() {
            _stateManager.StateChanged += OnStateChanged;
        }

        private void OnStateChanged(GameState state) {
            switch (state) {
                case GameState.Paused:
                    Show<PausePopup>();
                    break;
                case GameState.Win:
                    Show<CompletedPopup>();
                    break;
                case GameState.Lose:
                    Show<FailedPopup>();
                    break;
            }
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

        [PostInject]
        private void PostInject() {
            Subscribe();
        }

        private void OnPopupOpened(IPopup popup) {
            var handler = PopupOpened;
            if (handler != null) {
                handler.Invoke(popup, _popups.Count);
            }
        }

        private void OnPopupClosed(IPopup popup) {
            var handler = PopupClosed;
            if (handler != null) {
                handler.Invoke(popup, _popups.Count);
            }
        }
    }
}