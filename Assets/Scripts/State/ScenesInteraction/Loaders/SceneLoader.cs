// Created 22.10.2015
// Modified by Александр 01.11.2015 at 17:34

namespace Assets.Scripts.State.ScenesInteraction.Loaders {
    #region References

    using UnityEngine;

    #endregion

    internal class SceneLoader : ISceneLoader {
        public void GoToScene(Scene scene) {
            LoadScene(string.Format("{0}{1}", scene, "Scene"));
        }

        private void LoadScene(string sceneName) {
            Application.LoadLevel(sceneName);
        }
    }
}