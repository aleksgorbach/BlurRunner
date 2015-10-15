// Created 15.10.2015
// Modified by Александр 15.10.2015 at 21:09

namespace Assets.Scripts.UI.Menus.Levels.Presenter {
    #region References

    using Engine.Presenter;
    using State.Levels.Storage;

    #endregion

    internal class LevelChoosingPresenter : Presenter<ILevelChoosingMenuUI> {
        private readonly ILevelStorage _storage;

        public LevelChoosingPresenter(ILevelStorage storage) {
            _storage = storage;
        }

        public override void Init(ILevelChoosingMenuUI view) {
            base.Init(view);
            view.Init(_storage.TotalLevelsCount);
        }
    }
}