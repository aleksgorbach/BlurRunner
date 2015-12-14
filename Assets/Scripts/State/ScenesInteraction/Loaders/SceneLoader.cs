// Created 22.10.2015
// Modified by  14.12.2015 at 14:42

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

        private IEnumerator LoadScene() {
            yield return Resources.UnloadUnusedAssets();
            _loadingOperation = Application.LoadLevelAsync(_nextSceneName);
            yield return _loadingOperation;
            _loadingOperation = null;
        }
    }
}