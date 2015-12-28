// Created 05.11.2015
// Modified by  27.11.2015 at 14:44

namespace Assets.Scripts.State.ScenesInteraction.Controllers {
    #region References

    using Ads;
    using Engine;
    using Levels;
    using Levels.Storage;
    using Loaders;
    using UI.Menus.Levels;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    #endregion

    internal class LevelsController : MonoBehaviourBase {
        [SerializeField]
        private LevelsChoosingMenu _levelsMenu;

        [Inject]
        private ILevelStorage _levelStorage;

        [SerializeField]
        private Button _openShopButton;

        [Inject]
        private ISceneLoader _sceneLoader;

        [Inject]
        private IAdManager _adManager;

        protected override void Awake() {
            base.Awake();
            _openShopButton.onClick.AddListener(OpenShop);
            _levelsMenu.LevelChoosed += GoToGame;
        }

        private void GoToGame(ILevel level) {
            _levelStorage.SetCurrentLevel(level.Number);
            _sceneLoader.GoToScene(Scene.Game);
        }

        protected override void Start() {
            base.Start();
            _adManager.ShowBanner();
        }

        private void OpenShop() {
            _adManager.ShowFullscreen();
            _sceneLoader.GoToScene(Scene.Shop);
        }
    }
}