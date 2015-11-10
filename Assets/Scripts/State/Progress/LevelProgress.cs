// Created 09.11.2015 
// Modified by Gorbach Alex 10.11.2015 at 11:43

namespace Assets.Scripts.State.Progress {
    #region References

    using System;
    using Zenject;

    #endregion

    internal class LevelProgress : ILevelProgress {
        private int _score;

        public LevelProgress(int number) {
            Number = number;
            Score = 0;
        }

        public int Number { get; private set; }

        public int Score {
            get {
                return _score;
            }
            set {
                var old = _score;
                _score = value;
                if (old != _score) {
                    OnChanged();
                }
                if (_score < 0) {
                    OnBecameNegative();
                }
            }
        }

        public event Action<int> Changed;
        public event Action BecomeNegative;

        private void OnChanged() {
            var handler = Changed;
            if (handler != null) {
                handler.Invoke(Score);
            }
        }

        private void OnBecameNegative() {
            var handler = BecomeNegative;
            if (handler != null) {
                handler.Invoke();
            }
        }

        public class Factory : Factory<int, LevelProgress> {
        }
    }
}