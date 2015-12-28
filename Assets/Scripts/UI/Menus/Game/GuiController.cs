// Created 23.10.2015
// Modified by  28.12.2015 at 15:02

namespace Assets.Scripts.UI.Menus.Game {
    #region References

    using Engine;
    using Gameplay.GameState.Manager;
    using Popups;
    using Popups.Controller;
    using State.ScenesInteraction.Loaders;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    #endregion

    internal class GuiController : MonoBehaviourBase {
        #region Visible in inspector

        [SerializeField]
        private Button _backButton;

        [SerializeField]
        private Button _pauseButton;

        #endregion

        #region Injected dependencies

        [Inject]
        private IGameStateManager _stateManager;

        [Inject]
        private ISceneLoader _sceneLoader;

        [Inject]
        private IPopupController _popupController;

        #endregion

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

        private void OnPopupCountChanged(object sender, PopupEventArgs args) {
            if (args.OpenedPopupsCount > 0) {
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