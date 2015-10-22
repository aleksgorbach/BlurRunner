// Created 22.10.2015 
// Modified by Gorbach Alex 22.10.2015 at 14:46

namespace Assets.Scripts.UI.Menus.Levels {
    #region References

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Assets.Scripts.Engine;
    using Engine.Presenter;
    using LevelItem;
    using Presenter;
    using State.Levels;
    using Zenject;

    #region References

    using UnityEngine;

    #endregion

    #endregion

    internal class LevelsChoosingMenu : MonoBehaviourBase, ILevelChoosingMenu {
        private readonly int _fromLevel = 0;
        private IFactory<LevelItem.LevelItem> _factory;
        private IList<ILevelItem> _levels;

        [SerializeField]
        private int _size;

        public IEnumerable<ILevel> Levels {
            set {
                var array = value.ToArray();
                Array.Sort(array, (x, y) => x.Number.CompareTo(y.Number));
                _levels = array.Select(
                    x => {
                        var lvl = AddItem(_factory.Create());
                        lvl.Level = x;
                        lvl.LevelChoosed += OnLevelChoosed;
                        return lvl;
                    }).ToList();
            }
        }

        public event LevelChoosedDelegate LevelChoosed;

        private void OnLevelChoosed(ILevel level) {
            var handler = LevelChoosed;
            if (handler != null) {
                handler.Invoke(level);
            }
        }

        [PostInject]
        private void Inject(LevelItem.LevelItem.Factory factory, PresenterFactory presenterFactory) {
            _factory = factory;
            _levels = new List<ILevelItem>();
            var presenter = presenterFactory.Create<LevelChoosingPresenter, ILevelChoosingMenu>(this);
            presenter.Init(_fromLevel, _fromLevel + _size);
        }

        private ILevelItem AddItem(ILevelItem item) {
            var transf = GetComponent<RectTransform>();
            item.Transform.SetParent(transf, false);
            var width = item.Size.x;
            var length = 0f;
            foreach (var level in _levels) {
                length += level.Size.x;
            }
            (item.Transform as RectTransform).anchoredPosition = new Vector2(length, 0);
            _levels.Add(item);

            transf.sizeDelta = new Vector2(length + width, transf.sizeDelta.y);
            return item;
        }
    }
}