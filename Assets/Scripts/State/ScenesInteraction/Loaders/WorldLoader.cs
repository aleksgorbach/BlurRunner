// Created 16.12.2015
// Modified by  28.12.2015 at 10:45

namespace Assets.Scripts.State.ScenesInteraction.Loaders {
    #region References

    using System;
    using System.Collections;
    using Gameplay.Consts;
    using Zenject;

    #endregion

    internal class WorldLoader : InitializingLoader, IWorldLoader {
        private LevelWorld _world;

        #region Injected dependencies

        [Inject]
        private ISceneLoader _sceneLoader;

        [Inject(Identifiers.Levels.CurrentLevel)]
        private int _levelNumber;

        #endregion

        private IEnumerator LevelLoading() {
            //var sceneName = string.Format("Level_{0}", levelNumber);
            yield return _sceneLoader.LoadLevelAdditive(_levelNumber);
            _world = FindObjectOfType<LevelWorld>();
            OnLoaded(_world);
        }

        private void OnLoaded(LevelWorld world) {
            var handler = WorldLoaded;
            if (handler != null) {
                handler.Invoke(this, new WorldLoadedEventArgs(world));
            }
        }

        [PostInject]
        private void Load() {
            StartCoroutine(LevelLoading());
        }

        public class WorldLoadedEventArgs : EventArgs {
            public LevelWorld World { get; private set; }

            public WorldLoadedEventArgs(LevelWorld world) {
                World = world;
            }
        }

        public event EventHandler<WorldLoadedEventArgs> WorldLoaded;

        public override bool IsLoaded {
            get { return _world != null; }
        }
    }
}