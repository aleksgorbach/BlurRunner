// Created 07.11.2015
// Modified by Александр 07.11.2015 at 12:48

namespace Assets.Scripts.State.ScenesInteraction.Controllers {
    #region References

    using Engine;
    using Loaders;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    #endregion

    internal class ShopController : MonoBehaviourBase {
        [SerializeField]
        private Button _exitButton;

        [Inject]
        private ISceneLoader _sceneLoader;

        protected override void Awake() {
            base.Awake();
            _exitButton.onClick.AddListener(GoToMenu);
        }

        private void GoToMenu() {
            _sceneLoader.GoToScene(Scene.LevelChoose);
        }
    }
}