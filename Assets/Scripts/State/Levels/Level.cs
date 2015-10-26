// Created 20.10.2015
// Modified by Александр 26.10.2015 at 21:26

namespace Assets.Scripts.State.Levels {
    #region References

    using DataContracts.Models.Levels;
    using JetBrains.Annotations;

    #endregion

    internal class Level : ILevel {
        private readonly Difficulty _difficulty;
        private readonly float _length;
        private readonly int _number;

        public Level([NotNull] LevelData data) {
            _number = data.Number;
            _difficulty = data.Difficulty;
            _length = data.Length;
        }

        public int Number {
            get { return _number; }
        }

        public Difficulty Difficulty {
            get { return _difficulty; }
        }

        public float Length {
            get { return _length; }
        }
    }
}