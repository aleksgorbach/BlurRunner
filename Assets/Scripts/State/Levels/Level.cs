// Created 22.10.2015
// Modified by  23.11.2015 at 13:05

namespace Assets.Scripts.State.Levels {
    #region References

    using Data;
    using EndlessEngine.Decorations;
    using EndlessEngine.Obstacles;
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

        public DecorationItem[] Decorations {
            get { return _data.Decorations; }
        }

        public Obstacle[] Obstacles {
            get { return _data.Obstacles; }
        }

        public int Number {
            get { return _data.Number; }
        }

        public Sprite Background {
            get { return _data.Background; }
        }

        public Hero Hero {
            get { return _data.Hero; }
        }

        public Sprite Startpoint {
            get { return _data.Startpoint; }
        }

        public float Length {
            get { return _data.Length; }
        }
    }
}