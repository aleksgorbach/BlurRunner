// Created 15.10.2015
// Modified by Александр 19.10.2015 at 22:24

namespace Assets.Scripts.UI.Menus.Levels {
    #region References

    using System.Collections.Generic;
    using Engine.Presenter;
    using LevelItem;
    using Zenject;

    #region References

    using UnityEngine;

    #endregion

    #endregion

    internal class LevelsChoosingMenuUI : MonoBehaviour, ILevelChoosingMenuUI {
        private IFactory<LevelItemUI> _factory;
        //todo перенести создание уровней в презентер
        private IList<ILevelItemUI> _levels;

        public void Init(int totalLevelsCount) {
            for (var i = 0; i < totalLevelsCount; i++) {
                AddItem(_factory.Create(), i);
            }
        }

        [PostInject]
        private void Inject(IPresenter<ILevelChoosingMenuUI> presenter, LevelItemUI.Factory factory) {
            _factory = factory;
            _levels = new List<ILevelItemUI>();
            presenter.Init(this);
        }

        private void AddItem(ILevelItemUI item, int number) {
            var transf = GetComponent<RectTransform>();
            item.Transform.SetParent(transf, false);
            var width = item.Size.x;
            var length = 0f;
            foreach (var level in _levels) {
                length += level.Size.x;
            }
            (item.Transform as RectTransform).anchoredPosition = new Vector2(length, 0);
            item.Level = number;
            _levels.Add(item);

            transf.sizeDelta = new Vector2(length + width, transf.sizeDelta.y);
        }
    }
}