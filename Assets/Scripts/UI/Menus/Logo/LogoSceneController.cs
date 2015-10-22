// Created 22.10.2015
// Modified by Александр 22.10.2015 at 21:42

namespace Assets.Scripts.UI.Menus.Logo {
    #region References

    using Engine;
    using State.ScenesInteraction.Loaders;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    #endregion

    internal class LogoSceneController : MonoBehaviourBase {
        private ISceneLoader _loader;

        [SerializeField]
        private Button _playButton;

        protected override void Awake() {
            base.Awake();
            _playButton.onClick.AddListener(GoToMenu);
        }

        [PostInject]
        private void Init(ISceneLoader sceneLoader) {
            _loader = sceneLoader;
        }

        private void GoToMenu() {
            _loader.GoToNextScene();
        }
    }
}