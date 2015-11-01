// Created 20.10.2015
// Modified by Александр 01.11.2015 at 12:21

namespace Assets.Scripts.State.Levels {
    #region References

    using Data;
    using Gameplay.Heroes;
    using UnityEngine;

    #endregion

    #region References

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

        public Hero Hero { get { return _data.Hero; } }
    }
}