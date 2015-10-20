// Created 15.10.2015
// Modified by Александр 20.10.2015 at 18:59

namespace Assets.Scripts.UI.Menus.Levels.LevelItem {
    #region References

    using State.Levels;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    #endregion

    internal class LevelItem : MonoBehaviour, ILevelItem {
        private ILevel _level;

        [SerializeField]
        private Text _levelNumber;


        public ILevel Level {
            get { return _level; }
            set {
                _level = value;
                _levelNumber.text = "" + _level.Number;
            }
        }

        public event LevelChoosedDelegate LevelChoosed;

        public Vector2 Size {
            get {
                var transf = GetComponent<RectTransform>();
                return transf.sizeDelta;
            }
        }

        public Transform Transform {
            get { return transform; }
        }

        public void OnClick() {
            var handler = LevelChoosed;
            if (handler != null) {
                handler.Invoke(_level);
            }
        }

        public class Factory : GameObjectFactory<LevelItem> {
        }
    }
}