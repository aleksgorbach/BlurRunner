// Created 22.10.2015
// Modified by  19.11.2015 at 15:35

namespace Assets.Scripts.State.Progress {
    #region References

    using System;

    #endregion

    internal class LevelProgress : ILevelProgress {
        private int _score;

        public LevelProgress() {
            Score = 0;
        }

        public int Score {
            get { return _score; }
            set {
                var old = _score;
                _score = value;
                if (old != _score) {
                    OnChanged();
                }
            }
        }

        public event Action<int> Changed;

        private void OnChanged() {
            var handler = Changed;
            if (handler != null) {
                handler.Invoke(Score);
            }
        }
    }
}