// Created 02.11.2015
// Modified by  30.11.2015 at 14:02

namespace Assets.Scripts.State.Levels.Data {
    #region References

    using EndlessEngine.Decorations;
    using EndlessEngine.Ground;
    using EndlessEngine.Obstacles;
    using Engine;
    using Gameplay.Bonuses;
    using Gameplay.Heroes;
    using UnityEngine;

    #endregion

    internal class LevelData : MonoBehaviourBase {
        [SerializeField]
        private Sprite _background;

        [SerializeField]
        private Bonus[] _bonuses;

        [SerializeField]
        private Decoration[] _decorations;

        [SerializeField]
        private GroundBlock[] _ground;

        [SerializeField]
        private Hero _hero;

        [SerializeField]
        private GroundBlock[] _hills;

        [SerializeField]
        private float _length;

        [SerializeField]
        private int _levelNumber;

        [SerializeField]
        private Obstacle[] _obstacles;

        [SerializeField]
        private Sprite _startPoint;

        public int Number {
            get { return _levelNumber; }
        }

        public Sprite Background {
            get { return _background; }
        }

        public Hero Hero {
            get { return _hero; }
        }

        public float Length {
            get { return _length; }
        }

        public Sprite Startpoint {
            get { return _startPoint; }
        }

        public Decoration[] Decorations {
            get { return _decorations; }
        }

        public Obstacle[] Obstacles {
            get { return _obstacles; }
        }

        public GroundBlock[] Ground {
            get { return _ground; }
        }

        public Bonus[] Bonuses {
            get { return _bonuses; }
        }

        public GroundBlock[] Hills {
            get { return _hills; }
        }
    }
}