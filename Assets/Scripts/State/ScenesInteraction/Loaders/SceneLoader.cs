// Created 15.12.2015
// Modified by Александр 15.12.2015 at 21:18

namespace Assets.Scripts.State.ScenesInteraction.Loaders {
    #region References

    using System.Collections;
    using Engine;
    using UnityEngine;

    #endregion

    internal class SceneLoader : MonoBehaviourBase, ISceneLoader {
        private AsyncOperation _loadingOperation = null;
        private string _nextSceneName = "LoginScene";

        public float Progress {
            get {
                if (_loadingOperation == null) {
                    return 1;
                }
                return _loadingOperation.progress;
            }
        }

        public bool IsLoading {
            get { return _loadingOperation != null; }
        }


        public void GoToScene(Scene scene) {
            _nextSceneName = string.Format("{0}{1}", scene, "Scene");
            Application.LoadLevel("SplashScene");
            //Application.LoadLevel(_nextSceneName);
        }

        public void LoadNextScene() {
            StartCoroutine(LoadScene());
        }

        public IEnumerator LoadLevelAdditive(int number) {
            var sceneName = string.Format("Level_{0}", number);
            yield return Application.LoadLevelAdditiveAsync(sceneName);
        }

        private IEnumerator LoadScene() {
            yield return Resources.UnloadUnusedAssets();
            _loadingOperation = Application.LoadLevelAsync(_nextSceneName);
            yield return _loadingOperation;
            _loadingOperation = null;
        }
    }
}