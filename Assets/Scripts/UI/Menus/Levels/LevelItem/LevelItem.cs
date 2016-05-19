// Created 22.10.2015
// Modified by  27.11.2015 at 14:43

namespace Assets.Scripts.UI.Menus.Levels.LevelItem {
    #region References

    using Engine;
    using Engine.Utils;
    using State.Levels;
    using UnityEngine;
    using UnityEngine.UI;

    #endregion

    internal class LevelItem : MonoBehaviourBase, ILevelItem {
        [SerializeField]
        private SymbolText _ageText;

        [SerializeField]
        private Image _background;

        private ILevel _level;

        public ILevel Level {
            set {
                _level = value;
                _background.sprite = Resources.Load<Sprite>("Levels/Backgrounds/" + _level.Background);
                _ageText.Text = _level.HeroAge + "";
            }
        }

        public event LevelChoosedDelegate LevelChoosed;


        public void OnClick() {
            var handler = LevelChoosed;
            if (handler != null) {
                handler.Invoke(_level);
            }
        }
    }
}