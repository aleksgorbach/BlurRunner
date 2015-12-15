// Created 15.12.2015
// Modified by Александр 15.12.2015 at 21:33

namespace Assets.Scripts.State.ScenesInteraction.Loaders {
    #region References

    using System.Collections;
    using Engine;
    using Levels;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class WorldLoader : MonoBehaviourBase {
        [Inject]
        private Camera _camera;

        [Inject]
        private ILevel _level;

        [Inject]
        private ISceneLoader _sceneLoader;

        [PostInject]
        private void Inject() {
            StartCoroutine(LevelLoading());
        }

        private IEnumerator LevelLoading() {
            var sceneName = string.Format("Level_{0}", _level.Number);
            yield return Application.LoadLevelAdditiveAsync(sceneName);
            var world = FindObjectOfType<LevelWorld>();
            world.Camera = _camera;
            world.transform.SetParent(transform);
        }
    }
}