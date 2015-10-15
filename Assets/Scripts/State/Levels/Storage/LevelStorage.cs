// Created 15.10.2015
// Modified by Александр 15.10.2015 at 20:49

namespace Assets.Scripts.State.Levels.Storage {
    internal class LevelStorage : ILevelStorage {
        private const int LEVELS_COUNT = 10;

        public int TotalLevelsCount {
            get { return LEVELS_COUNT; }
        }
    }
}