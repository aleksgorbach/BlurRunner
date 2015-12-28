// Created 16.12.2015
// Modified by  28.12.2015 at 9:10

namespace Assets.Scripts.State.ScenesInteraction.Loaders {
    #region References

    using System;
    using System.Collections;
    using Engine;
    using Zenject;

    #endregion

    internal class WorldLoader : MonoBehaviourBase {
        private LevelWorld _world;

        [Inject]
        private ISceneLoader _sceneLoader;

        private IEnumerator LevelLoading(int levelNumber, Action<LevelWorld> onLoaded) {
            //var sceneName = string.Format("Level_{0}", levelNumber);
            yield return _sceneLoader.LoadLevelAdditive(levelNumber);
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