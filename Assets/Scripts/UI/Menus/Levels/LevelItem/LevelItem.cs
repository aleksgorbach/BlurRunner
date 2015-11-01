// Created 22.10.2015
// Modified by Александр 01.11.2015 at 17:54

namespace Assets.Scripts.UI.Menus.Levels.LevelItem {
    #region References

    using Engine;
    using State.Levels;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    #endregion

    internal class LevelItem : MonoBehaviourBase, ILevelItem {
        [SerializeField]
        private Image _background;

        private ILevel _level;

        public ILevel Level {
            set {
                _level = value;
                _background.sprite = _level.Background;
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