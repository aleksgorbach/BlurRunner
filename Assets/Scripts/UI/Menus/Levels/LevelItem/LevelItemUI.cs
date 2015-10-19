// Created 15.10.2015
// Modified by Александр 19.10.2015 at 22:23

namespace Assets.Scripts.UI.Menus.Levels.LevelItem {
    #region References

    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    #endregion

    internal class LevelItemUI : MonoBehaviour, ILevelItemUI {
        private int _level;
        [SerializeField] private Text _levelNumber;

        public int Level {
            get { return _level; }
            set {
                _level = value;
                _levelNumber.text = "" + value;
            }
        }

        public Vector2 Size {
            get {
                var transf = GetComponent<RectTransform>();
                return transf.sizeDelta;
            }
        }

        public Transform Transform {
            get { return transform; }
        }

        public class Factory : GameObjectFactory<LevelItemUI> {
        }
    }
}