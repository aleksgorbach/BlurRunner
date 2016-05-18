// Created 20.10.2015
// Modified by  23.11.2015 at 10:54

namespace Assets.Scripts.State.Levels.Storage {
    #region References

    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Loaders;

    #endregion

    internal class LevelStorage : ILevelStorage {
        private int _currentLevelNumber;
        private Dictionary<int, Level> _levels;

        public LevelStorage(ILevelLoader loader) {
            loader.Loaded += OnLoaded;
            loader.Load();
        }

        public ILevel this[int levelNumber] {
            get { return _levels[levelNumber]; }
        }

        public ILevel CurrentLevel {
            get { return _levels[_currentLevelNumber]; }
        }

        public void SetCurrentLevel(int levelNumber) {
            _currentLevelNumber = levelNumber;
        }

        public IEnumerator<ILevel> GetEnumerator() {
            return _levels.Select(x => (ILevel) x.Value).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        private void OnLoaded(List<LevelData> data) {
            _levels = data.ToDictionary(x => x.Number, x => new Level(x));
        }
    }
}