// Created 22.10.2015 
// Modified by Gorbach Alex 06.11.2015 at 15:12

namespace Assets.Scripts.State.Progress.Storage {
    #region References

    using System.Collections.Generic;
    using System.Linq;
    using Score;

    #endregion

    internal class ProgressStorage : IProgressStorage {
        private readonly LevelProgress.Factory _factory;
        private readonly IList<ILevelProgress> _levelsProgress;

        //todo избавиться здесь от зависимости от IScoreSource, потому что this - глобальный, а сурс - локальный в игре
        public ProgressStorage(LevelProgress.Factory factory /*, IScoreSource scoreSource*/) {
            _factory = factory;
            _levelsProgress = new List<ILevelProgress>();
            //scoreSource.ScoreChanged += OnScoreChanged;
            SetCurrentLevel(0);
        }

        public ILevelProgress this[int levelNumber] {
            get {
                return _levelsProgress.FirstOrDefault(x => x.Number == levelNumber);
            }
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