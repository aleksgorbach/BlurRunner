// Created 15.10.2015
// Modified by Александр 20.10.2015 at 20:29

namespace Assets.Scripts.UI.Menus.Levels {
    #region References

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Engine.Presenter;
    using LevelItem;
    using Presenter;
    using State.Levels;
    using Zenject;

    #region References

    using UnityEngine;

    #endregion

    #endregion

    internal class LevelsChoosingMenu : MonoBehaviour, ILevelChoosingMenu {
        private IFactory<LevelItem.LevelItem> _factory;

        private readonly int _fromLevel = 0;
        private IList<ILevelItem> _levels;

        [SerializeField]
        private int _size;

        public IEnumerable<ILevel> Levels {
            set {
                var array = value.ToArray();
                Array.Sort(array, (x, y) => x.Number.CompareTo(y.Number));
                _levels = array.Select(x => {
                    var lvl = AddItem(_factory.Create());
                    lvl.Level = x;
                    return lvl;
                }).ToList();
            }
        }

        [PostInject]
        private void Inject(LevelItem.LevelItem.Factory factory, PresenterFactory presenterFactory) {
            _factory = factory;
            _levels = new List<ILevelItem>();
            var presenter = presenterFactory.Create<LevelChoosingPresenter, ILevelChoosingMenu>(this);
            presenter.Init(_fromLevel, _fromLevel + _size);
        }

        private void Awake() {
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