// Created 16.12.2015
// Modified by  24.12.2015 at 10:29

namespace Assets.Scripts.State.ScenesInteraction.Loaders {
    #region References

    using System;
    using System.Collections;
    using Engine;
    using UnityEngine.SceneManagement;

    #endregion

    internal class WorldLoader : MonoBehaviourBase {
        private LevelWorld _world;

        private IEnumerator LevelLoading(int levelNumber, Action<LevelWorld> onLoaded) {
            var sceneName = string.Format("Level_{0}", levelNumber);
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
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

        public class WorldLoadedEventArgs : EventArgs {
            public LevelWorld World { get; private set; }

            public WorldLoadedEventArgs(LevelWorld world) {
                World = world;
            }
        }
    }
}