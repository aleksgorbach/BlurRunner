// Created 15.10.2015
// Modified by Александр 15.10.2015 at 21:14

namespace Assets.Scripts.UI.Menus.Levels {
    #region References

    using Engine.Presenter;
    using LevelItem;
    using Zenject;

    #region References

    using UnityEngine;

    #endregion

    #endregion

    internal class LevelsChoosingMenuUI : MonoBehaviour, ILevelChoosingMenuUI {
        private IFactory<LevelItemUI> _factory;

        public void Init(int totalLevelsCount) {
            for (var i = 0; i < totalLevelsCount; i++) {
                var level = _factory.Create();
                level.transform.SetParent(transform);
            }
        }

        [PostInject]
        private void Inject(IPresenter<ILevelChoosingMenuUI> presenter, IFactory<LevelItemUI> factory) {
            _factory = factory;
            presenter.Init(this);
        }
    }
}