// Created 16.12.2015
// Modified by  18.12.2015 at 16:17

namespace Assets.Scripts.State.ScenesInteraction.Loaders {
    #region References

    using System;
    using System.Collections;
    using Engine;
    using UnityEngine;

    #endregion

    internal class WorldLoader : MonoBehaviourBase {
        private LevelWorld _world = null;

        private IEnumerator LevelLoading(int levelNumber, Action<LevelWorld> onLoaded) {
            var sceneName = string.Format("Level_{0}", levelNumber);
            yield return Application.LoadLevelAdditiveAsync(sceneName);
            _world = FindObjectOfType<LevelWorld>();
            onLoaded(_world);
        }

        public void Load(int levelNumber, Action<LevelWorld> onLoaded) {
            if (_world != null) {
                onLoaded(_world);
                return;
            }
            StartCoroutine(LevelLoading(levelNumber, onLoaded));
        }
    }
}