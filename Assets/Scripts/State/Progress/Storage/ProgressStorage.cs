// Created 09.11.2015 
// Modified by Gorbach Alex 09.11.2015 at 17:31

namespace Assets.Scripts.State.Progress.Storage {
    #region References

    using System.Collections.Generic;
    using System.Linq;
    using Score;

    #endregion

    internal class ProgressStorage : IProgressStorage {
        private readonly LevelProgress.Factory _factory;
        private readonly IList<ILevelProgress> _levelsProgress;

        public ProgressStorage(LevelProgress.Factory factory) {
            _factory = factory;
            _levelsProgress = new List<ILevelProgress>();
            SetCurrentLevel(0);
        }

        public ILevelProgress this[int levelNumber] {
            get {
                return _levelsProgress.FirstOrDefault(x => x.Number == levelNumber);
            }
        }

        public ILevelProgress CurrentLevelProgress { get; private set; }

        public void SetCurrentLevel(int number) {
            CurrentLevelProgress = _levelsProgress.FirstOrDefault(x => x.Number == number);
            if (CurrentLevelProgress == null) {
                CurrentLevelProgress = _factory.Create(number);
                _levelsProgress.Add(CurrentLevelProgress);
            }
        }
    }
}