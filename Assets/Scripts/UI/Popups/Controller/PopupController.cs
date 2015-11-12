// Created 23.10.2015 
// Modified by Gorbach Alex 12.11.2015 at 10:30

namespace Assets.Scripts.UI.Popups.Controller {
    #region References

    using System;
    using System.Collections.Generic;
    using Gameplay.Consts;
    using Implementations;
    using Gameplay.GameState.Manager;
    using Engine;
    using Factory;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class PopupController : MonoBehaviourBase, IPopupController {
        [SerializeField]
        private PopupPool _pool;

        private PopupStrategy _strategy;

        [Inject]
        private IGameStateManager _stateManager;

        private Stack<Popup> _popups;

        public event Action<IPopup, int> PopupOpened;
        public event Action<IPopup, int> PopupClosed;

        private IPopup Show<TPopup>() where TPopup : Popup {
            _strategy.SetTarget<TPopup>();
            var popup = _pool.Get();
            popup.gameObject.SetActive(true);
            popup.transform.SetParent(transform);
            popup.rectTransform.anchoredPosition = Vector2.zero;
            popup.rectTransform.offsetMax = Vector2.zero;
            popup.rectTransform.offsetMin = Vector2.zero;
            _popups.Push(popup);
            Subscribe(popup);
            OnPopupOpened(popup);
            return popup;
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

        private void OnClose(IPopup popup) {
            if (_popups.Count > 0) {
                var top = _popups.Pop();
                Unsubscribe(top);
                _pool.Release(top);
                OnPopupClosed(popup);
            }
        }

        protected override void Awake() {
            base.Awake();
            _popups = new Stack<Popup>();
            _strategy = _pool.Strategy as PopupStrategy;
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