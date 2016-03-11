// Created 22.10.2015
// Modified by  28.12.2015 at 10:47

namespace Assets.Scripts.State.ScenesInteraction.Loaders {
    #region References

    using System.Collections;
    using System.Linq;
    using Engine;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using UnityEngine.UI;

    #endregion

    internal class SceneLoader : MonoBehaviourBase, ISceneLoader {
        private const float FADE_DURATION = .5f;

        #region Visible in inspector

        [SerializeField]
        private Image _loadingScreen;

        #endregion

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
            LoadNextScene();
            //SceneManager.LoadScene("SplashScene");
        }

        private void LoadNextScene() {
            StartCoroutine(LoadScene());
        }

        public IEnumerator LoadLevelAdditive(int number) {
            var sceneName = string.Format("Level_{0}", number);
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        }

        private IEnumerator LoadScene() {
            yield return StartCoroutine(LoadingFadeIn());

            _loadingOperation = SceneManager.LoadSceneAsync(_nextSceneName);
            yield return _loadingOperation;
            yield return Resources.UnloadUnusedAssets();
            var loaders = FindObjectsOfType(typeof (InitializingLoader)) as InitializingLoader[];
            while (loaders != null && loaders.Any(loader => !loader.IsLoaded)) {
                yield return null;
            }
            yield return StartCoroutine(LoadingFadeOut());
            _loadingOperation = null;
        }

        private IEnumerator LoadingFadeIn() {
            var time = 0f;
            while (time < FADE_DURATION) {
                _loadingScreen.color = new Color(_loadingScreen.color.r, _loadingScreen.color.g, _loadingScreen.color.b,
                    time/FADE_DURATION);
                time += Time.deltaTime;
                yield return null;
            }
        }

        private IEnumerator LoadingFadeOut() {
            var time = 0f;
            while (time < FADE_DURATION) {
                _loadingScreen.color = new Color(_loadingScreen.color.r, _loadingScreen.color.g, _loadingScreen.color.b,
                    1 - time/FADE_DURATION);
                time += Time.deltaTime;
                yield return null;
            }
        }
    }
}