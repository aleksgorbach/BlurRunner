// Created 23.10.2015 
// Modified by Gorbach Alex 11.11.2015 at 14:04

namespace Assets.Scripts.UI.Menus.Game {
    #region References

    using Popups;
    using Gameplay.GameState.Manager;
    using Engine;
    using Popups.Controller;
    using State.ScenesInteraction.Loaders;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    #endregion

    internal class GuiController : MonoBehaviourBase {
        [SerializeField]
        private Button _backButton;

        [SerializeField]
        private Button _pauseButton;

        [Inject]
        private IGameStateManager _stateManager;

        [Inject]
        private ISceneLoader _sceneLoader;

        [Inject]
        private IPopupController _popupController;

        protected override void Awake() {
            base.Awake();
            _pauseButton.onClick.AddListener(OnPause);
            _backButton.onClick.AddListener(Exit);
        }

        [PostInject]
        private void PostInject() {
            _popupController.PopupOpened += OnPopupCountChanged;
            _popupController.PopupClosed += OnPopupCountChanged;
        }

        private void OnPopupCountChanged(IPopup popup, int activePopupsCount) {
            if (activePopupsCount > 0) {
                _stateManager.Pause();
            }
            else {
                _stateManager.Resume();
            }
        }

        private void Exit() {
            _sceneLoader.GoToScene(Scene.LevelChoose);
        }

        private void OnPause() {
            _stateManager.Pause();
        }
    }
}