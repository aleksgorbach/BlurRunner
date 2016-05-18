// Created 02.11.2015
// Modified by  30.11.2015 at 14:02

namespace Assets.Scripts.State.Levels.Data {
    #region References

    using Engine;
    using UnityEngine;

    #endregion

    internal class LevelData : MonoBehaviourBase {
        [SerializeField]
        private Sprite _background;

        [SerializeField]
        private int _levelNumber;

        [SerializeField]
        private int _age;

        public int Number {
            get { return _levelNumber; }
        }

        public Sprite Background {
            get { return _background; }
        }

        public int HeroAge {
            get { return _age; }
        }
    }
}