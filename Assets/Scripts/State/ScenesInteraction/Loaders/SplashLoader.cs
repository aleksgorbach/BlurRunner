// Created 07.12.2015
// Modified by  07.12.2015 at 11:05

namespace Assets.Scripts.State.ScenesInteraction.Loaders {
    #region References

    using System.Collections;
    using Engine;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    #endregion

    internal class SplashLoader : MonoBehaviourBase {
        [SerializeField]
        private Text _loadingProgress;

        [Inject]
        private ISceneLoader _sceneLoader;

        [PostInject]
        private void PostInject() {
            StartCoroutine(LoadingCoroutine());
            _sceneLoader.LoadNextScene();
        }

        private IEnumerator LoadingCoroutine() {
            while (_sceneLoader.IsLoading) {
                _loadingProgress.text = string.Format("{0}%", (int) (_sceneLoader.Progress*100));
                yield return new WaitForSeconds(0.2f);
            }
        }
    }
}