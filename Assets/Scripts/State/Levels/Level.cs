// Created 22.10.2015
// Modified by  30.11.2015 at 14:01

namespace Assets.Scripts.State.Levels {
    #region References

    using Data;
    using UnityEngine;

    #endregion

    internal class Level : ILevel {
        private readonly LevelData _data;

        public Level(LevelData data) {
            _data = data;
        }

        public int Number {
            get { return _data.Number; }
        }

        public Sprite Background {
            get { return _data.Background; }
        }

        public int HeroAge {
            get { return _data.HeroAge; }
        }
    }
}