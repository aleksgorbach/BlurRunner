// Created 15.10.2015
// Modified by Александр 20.10.2015 at 20:27

namespace Assets.Scripts.UI.Menus.Levels.Presenter {
    #region References

    #region References

    using Engine.Presenter;
    using State.Levels.Storage;
    using Zenject;

    #endregion

    #endregion

    internal class LevelChoosingPresenter : Presenter<ILevelChoosingMenu> {
        private ILevelStorage _storage;

        internal void Init(int fromLevel, int toLevel) {
            View.Levels = _storage.Get(fromLevel, toLevel);
        }

        [PostInject]
        private void Init(ILevelStorage storage) {
            _storage = storage;
        }
    }
}