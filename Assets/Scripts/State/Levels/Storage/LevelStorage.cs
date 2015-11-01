// Created 15.10.2015
// Modified by Александр 01.11.2015 at 17:28

namespace Assets.Scripts.State.Levels.Storage {
    #region References

    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Loaders;

    #endregion

    internal class LevelStorage : ILevelStorage {
        private Dictionary<int, Level> _levels;

        public LevelStorage(ILevelLoader loader) {
            loader.Loaded += OnLoaded;
            loader.Load();
        }

        public ILevel this[int levelNumber] {
            get { return _levels[levelNumber]; }
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