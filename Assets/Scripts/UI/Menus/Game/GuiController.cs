// Created 23.10.2015 
// Modified by Gorbach Alex 05.11.2015 at 10:29

namespace Assets.Scripts.UI.Menus.Game {
    #region References

    using Assets.Scripts.UI.Popups.Implementations;
    using Engine;
    using Popups;
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

        private IPopupController _popupController;
        private ISceneLoader _sceneLoader;

        [PostInject]
        private void Inject(IPopupController popupController, ISceneLoader sceneLoader) {
            _popupController = popupController;
            _sceneLoader = sceneLoader;
        }

        protected override void Awake() {
            base.Awake();
            _pauseButton.onClick.AddListener(Pause);
            _backButton.onClick.AddListener(Exit);
        }

        private void Exit() {
            _sceneLoader.GoToScene(Scene.LevelChoose);
        }

        private void Pause() {
            _popupController.Show<PausePopup>().Click += ClosePopup;
            //todo вместо этого вызывать Game.Pause();
            Time.timeScale = 0;
        }

        private void ClosePopup(IPopup popup) {
            _popupController.Close();
            Time.timeScale = 1;
        }
    }
}