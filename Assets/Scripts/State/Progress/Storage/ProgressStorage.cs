// Created 21.10.2015
// Modified by Александр 05.11.2015 at 20:46

namespace Assets.Scripts.State.Progress.Storage {
    #region References

    using System.Collections.Generic;
    using System.Linq;

    #endregion

    internal class ProgressStorage : IProgressStorage {
        private readonly LevelProgress.Factory _factory;
        private readonly IList<ILevelProgress> _levelsProgress;

        public ProgressStorage(LevelProgress.Factory factory) {
            _factory = factory;
            _levelsProgress = new List<ILevelProgress>();
            // scoreSource.ScoreChanged += OnScoreChanged;
            SetCurrentLevel(0);
        }

        public ILevelProgress this[int levelNumber] {
            get { return _levelsProgress.FirstOrDefault(x => x.Number == levelNumber); }
        }

        public ILevelProgress CurrentLevelProgress { get; private set; }

        public void SetCurrentLevel(int number) {
            CurrentLevelProgress = _factory.Create(number);
        }

        private void OnScoreChanged(int currentScore) {
            // обойтись без открытого сеттера
            CurrentLevelProgress.Score = currentScore;
        }
    }
}