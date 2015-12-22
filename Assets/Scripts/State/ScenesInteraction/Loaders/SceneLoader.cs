// Created 22.10.2015
// Modified by  22.12.2015 at 16:06

namespace Assets.Scripts.State.ScenesInteraction.Loaders {
    #region References

    using System.Collections;
    using Engine;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    #endregion

    internal class SceneLoader : MonoBehaviourBase, ISceneLoader {
        private AsyncOperation _loadingOperation;
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
            SceneManager.LoadScene("SplashScene");
            //Application.LoadLevel(_nextSceneName);
        }

        public void LoadNextScene() {
            StartCoroutine(LoadScene());
        }

        public IEnumerator LoadLevelAdditive(int number) {
            var sceneName = string.Format("Level_{0}", number);
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        }

        private IEnumerator LoadScene() {
            yield return Resources.UnloadUnusedAssets();
            _loadingOperation = SceneManager.LoadSceneAsync(_nextSceneName);
            yield return _loadingOperation;
            _loadingOperation = null;
        }
    }
}