// Created 23.10.2015
// Modified by  28.01.2016 at 12:27

namespace Assets.Scripts.UI.Menus.Game {
    #region References

    using Engine;
    using Gameplay.GameState.Manager;
    using Popups;
    using Popups.Controller;
    using State.ScenesInteraction.Loaders;
    using Zenject;

    #endregion

    internal class GuiController : MonoBehaviourBase {
        #region Injected dependencies

        [Inject]
        private IGameStateManager _stateManager;

        [Inject]
        private ISceneLoader _sceneLoader;

        [Inject]
        private IPopupController _popupController;

        #endregion

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

        public void Exit() {
            _sceneLoader.GoToScene(Scene.LevelChoose);
        }

        public void OnPause() {
            _stateManager.Pause();
        }
    }
}