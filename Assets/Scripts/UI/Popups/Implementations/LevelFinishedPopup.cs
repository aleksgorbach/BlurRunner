// Created 11.11.2015 
// Modified by Gorbach Alex 12.11.2015 at 11:36

namespace Assets.Scripts.UI.Popups.Implementations {
    #region References

    using State.ScenesInteraction.Loaders;
    using Zenject;

    #endregion

    internal abstract class LevelFinishedPopup : Popup {
        [Inject]
        private ISceneLoader _sceneLoader;

        protected override void OnClose() {
            base.OnClose();
            _sceneLoader.GoToScene(Scene.LevelChoose);
        }
    }
}