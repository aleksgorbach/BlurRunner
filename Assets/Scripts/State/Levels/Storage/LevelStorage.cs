// Created 15.10.2015
// Modified by Александр 20.10.2015 at 20:39

namespace Assets.Scripts.State.Levels.Storage {
    #region References

    using System.Collections.Generic;

    #endregion

    internal class LevelStorage : ILevelStorage {
        private readonly IDictionary<int, ILevel> _levels;

        public LevelStorage() {
            _levels = new Dictionary<int, ILevel>();

            for (var i = 0; i < 10; i++) {
                _levels.Add(i, new Level(i));
            }
        }

        public int TotalLevelsCount {
            get { return _levels.Count; }
        }

        public IEnumerable<ILevel> Get(int fromLevel, int toLevel) {
            for (var i = fromLevel; i <= toLevel; i++) {
                yield return _levels[i];
            }
        }
    }
}