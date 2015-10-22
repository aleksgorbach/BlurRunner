// Created 22.10.2015 
// Modified by Gorbach Alex 22.10.2015 at 13:01

namespace Assets.Scripts.UI.Menus.Levels.LevelItem {
    #region References

    using Visualizers.Stars;
    using Engine;
    using State.Levels;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    #endregion

    internal class LevelItem : MonoBehaviourBase, ILevelItem {
        private ILevel _level;

        [SerializeField]
        private Text _levelNumber;

        [SerializeField]
        private StarsVisualizer _starsVisualizer;

        public ILevel Level {
            get {
                return _level;
            }
            set {
                _level = value;
                _levelNumber.text = "" + _level.Number;
                _starsVisualizer.LevelNumber = _level.Number;
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
            get {
                return transform;
            }
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