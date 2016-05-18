// Created 22.10.2015
// Modified by  28.01.2016 at 12:38

namespace Assets.Scripts.UI.Menus.Levels {
    #region References

    using Engine;
    using LevelItem;
    using State.Levels;
    using State.Levels.Storage;
    using State.ScenesInteraction.Loaders;
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

        [Inject]
        private ISceneLoader _sceneLoader;


        public event LevelChoosedDelegate LevelChoosed;

        private void OnLevelChoosed(ILevel level) {
            var handler = LevelChoosed;
            if (handler != null) {
                handler.Invoke(level);
            }
            GoToGame(level);
        }

        [PostInject]
        private void PostInject() {
            var length = 0f;
            foreach (var level in _levelStorage) {
                var item = _factory.Create();
                item.transform.SetParent(transform);
                var width = item.rectTransform.sizeDelta.x;
                item.rectTransform.anchoredPosition = new Vector2(length, 0);
                item.rectTransform.localScale = Vector3.one;
                length += width;
                item.Level = level;
                item.LevelChoosed += OnLevelChoosed;
            }

            rectTransform.sizeDelta = new Vector2(length, rectTransform.sizeDelta.y);
        }

        protected virtual void GoToGame(ILevel level) {
            _levelStorage.SetCurrentLevel(level.Number);
            _sceneLoader.GoToScene(Scene.Game);
        }
    }
}