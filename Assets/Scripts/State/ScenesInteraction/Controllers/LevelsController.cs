// Created 05.11.2015
// Modified by  27.11.2015 at 14:44

namespace Assets.Scripts.State.ScenesInteraction.Controllers {
    #region References

    using Ads;
    using Engine;
    using Loaders;
    using UI.Popups.Controller;
    using UI.Popups.Implementations;
    using Zenject;

    #endregion

    internal class LevelsController : MonoBehaviourBase {
        [Inject]
        private ISceneLoader _sceneLoader;

        [Inject]
        private IAdManager _adManager;

        [Inject]
        private IPopupController _popupController;

        protected override void Start() {
            base.Start();
            _adManager.ShowBanner();
        }

        public void OpenShop() {
            _adManager.ShowFullscreen();
            _sceneLoader.GoToScene(Scene.Shop);
        }

        public void OpenSettings() {
            _popupController.Show<SettingsPopup>();
        }

        public void BackToSplash() {
            _sceneLoader.GoToScene(Scene.Splash);
        }
    }
}