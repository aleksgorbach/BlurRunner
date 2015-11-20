﻿// Created 02.11.2015
// Modified by  20.11.2015 at 10:24

namespace Assets.Scripts.State.Levels.Data {
    #region References

    using EndlessEngine.Decorations;
    using Engine;
    using Gameplay.Heroes;
    using UnityEngine;

    #endregion

    internal class LevelData : MonoBehaviourBase {
        [SerializeField]
        private Sprite _background;

        [SerializeField]
        private DecorationItem[] _decorations;

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

        public DecorationItem[] Decorations {
            get { return _decorations; }
        }
    }
}