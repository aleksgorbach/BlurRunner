// Created 23.10.2015 
// Modified by Gorbach Alex 06.11.2015 at 8:35

namespace Assets.Scripts.UI.Menus.Game {
    #region References

    using System;
    using Assets.Scripts.Gameplay.GameState.StateChangedSources;
    using Assets.Scripts.UI.Popups.Implementations;
    using Engine;
    using Popups;
    using Popups.Controller;
    using State.ScenesInteraction.Loaders;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    #endregion

    internal class GuiController : MonoBehaviourBase, IPauseSource {
        [SerializeField]
        private Button _backButton;

        [SerializeField]
        private Button _pauseButton;

        private ISceneLoader _sceneLoader;

        public event Action Pause;

        [PostInject]
        private void Inject(ISceneLoader sceneLoader) {
            _sceneLoader = sceneLoader;
        }

        protected override void Awake() {
            base.Awake();
            _pauseButton.onClick.AddListener(OnPause);
            _backButton.onClick.AddListener(Exit);
        }

        private void Exit() {
            _sceneLoader.GoToScene(Scene.LevelChoose);
        }

        private void OnPause() {
            //_popupController.Show<PausePopup>().Click += ClosePopup;
            //todo вместо этого вызывать Game.Pause();
            //Time.timeScale = 0;
            var handler = Pause;
            if (handler != null) {
                handler.Invoke();
            }
        }
    }
}