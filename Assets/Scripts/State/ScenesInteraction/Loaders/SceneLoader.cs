// Created 22.10.2015 
// Modified by Gorbach Alex 22.10.2015 at 14:55

namespace Assets.Scripts.State.ScenesInteraction.Loaders {
    #region References

    using Dependencies;
    using UnityEngine;

    #endregion

    internal class SceneLoader : ISceneLoader {
        private readonly ISceneOrder _sceneOrder;

        public SceneLoader(ISceneOrder sceneOrder) {
            _sceneOrder = sceneOrder;
        }

        public bool GoToNextScene() {
            return LoadScene(_sceneOrder.GetNextScene());
        }

        public bool GoToPreviousScene() {
            return LoadScene(_sceneOrder.GetPreviousScene());
        }

        private bool LoadScene(string sceneName) {
            if (string.IsNullOrEmpty(sceneName)) {
                return false;
            }
            Application.LoadLevel(sceneName);
            return true;
        }
    }
}