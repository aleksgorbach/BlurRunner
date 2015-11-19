// Created 31.10.2015
// Modified by Александр 19.11.2015 at 21:21

namespace Assets.Scripts.State.Levels.Data {
    #region References

    using Engine;
    using Gameplay.Heroes;
    using UnityEngine;

    #endregion

    internal class LevelData : MonoBehaviourBase {
        [SerializeField]
        private Sprite _background;

        [SerializeField]
        private Hero _hero;

        [SerializeField]
        private float _length;

        [SerializeField]
        private int _levelNumber;

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
    }
}