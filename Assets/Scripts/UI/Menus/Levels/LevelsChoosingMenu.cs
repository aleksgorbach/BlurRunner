// Created 22.10.2015
// Modified by  27.11.2015 at 14:42

namespace Assets.Scripts.UI.Menus.Levels {
    #region References

    using Engine;
    using LevelItem;
    using State.Levels;
    using State.Levels.Storage;
    using Zenject;

    #region References

    using UnityEngine;

    #endregion

    #endregion

    internal class LevelsChoosingMenu : MonoBehaviourBase, ILevelChoosingMenu {
        [Inject]
        private IFactory<LevelItem.LevelItem> _factory;

        [Inject]
        private ILevelStorage _levelStorage;


        public event LevelChoosedDelegate LevelChoosed;

        private void OnLevelChoosed(ILevel level) {
            var handler = LevelChoosed;
            if (handler != null) {
                handler.Invoke(level);
            }
        }

        [PostInject]
        private void PostInject() {
            var length = 0f;
            foreach (var level in _levelStorage) {
                var item = _factory.Create();
                item.transform.SetParent(transform);
                var width = item.rectTransform.sizeDelta.x;
                item.rectTransform.anchoredPosition = new Vector2(length, 0);
                length += width;
                item.Level = level;
                item.LevelChoosed += OnLevelChoosed;
            }

            rectTransform.sizeDelta = new Vector2(length, rectTransform.sizeDelta.y);
        }
    }
}