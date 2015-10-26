// Created 15.10.2015
// Modified by Александр 26.10.2015 at 21:26

namespace Assets.Scripts.State.Levels.Storage {
    #region References

    using System.Collections.Generic;
    using System.Linq;
    using DataContracts.Models.Levels;
    using Loaders;

    #endregion

    internal class LevelStorage : ILevelStorage {
        private Dictionary<int, Level> _levels;

        public LevelStorage(ILevelLoader loader) {
            loader.Loaded += OnLoaded;
            loader.Load();
        }

        public int TotalLevelsCount {
            get { return _levels.Count; }
        }

        public IEnumerable<ILevel> Get(int fromLevel, int toLevel) {
            for (var i = fromLevel; i <= toLevel; i++) {
                yield return _levels[i];
            }
        }

        public ILevel this[int levelNumber] {
            get { return _levels[levelNumber]; }
        }

        private void OnLoaded(IEnumerable<LevelData> data) {
            _levels = data.ToDictionary(x => x.Number, x => new Level(x));
        }
    }
}