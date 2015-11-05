// Created 31.10.2015
// Modified by Александр 01.11.2015 at 12:05

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
        private int _levelNumber;

        [SerializeField]
        private float _length;

        public int Number {
            get { return _levelNumber; }
        }

        public Sprite Background { get { return _background; } }
        public Hero Hero { get { return _hero; } }

        public float Length { get { return _length; } }
    }
}