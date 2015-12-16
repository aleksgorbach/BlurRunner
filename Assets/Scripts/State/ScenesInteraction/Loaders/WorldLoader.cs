// Created 15.12.2015
// Modified by Александр 16.12.2015 at 21:45

namespace Assets.Scripts.State.ScenesInteraction.Loaders {
    #region References

    using System.Collections;
    using Engine;
    using Gameplay;
    using Levels;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class WorldLoader : MonoBehaviourBase {
        [Inject]
        private Camera _camera;

        [Inject]
        private IGame _game;

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
            _game.World = world;
        }
    }
}