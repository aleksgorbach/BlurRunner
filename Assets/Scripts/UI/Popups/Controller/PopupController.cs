// Created 23.10.2015 
// Modified by Gorbach Alex 06.11.2015 at 9:48

namespace Assets.Scripts.UI.Popups.Controller {
    #region References

    using System;
    using System.Collections.Generic;
    using Gameplay.Consts;
    using Implementations;
    using Gameplay.GameState.Manager;
    using Gameplay.GameState.StateChangedSources;
    using Engine;
    using Factory;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class PopupController : MonoBehaviourBase, IPopupController, IRunSource {
        [Inject]
        private PopupPool _pool;

        [Inject]
        private IGameStateManager _stateManager;

        private Stack<Popup> _popups;

        public event Action Run;

        private IPopup Show<TPopup>() where TPopup : Popup {
            var popup = _pool.Get<TPopup>();
            popup.transform.SetParent(transform);
            popup.rectTransform.anchoredPosition = Vector2.zero;
            popup.rectTransform.offsetMax = Vector2.zero;
            popup.rectTransform.offsetMin = Vector2.zero;
            _popups.Push(popup);
            Subscribe(popup);
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
                OnResume();
            }
        }

        private void OnResume() {
            var handler = Run;
            if (handler != null) {
                handler.Invoke();
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
    }
}