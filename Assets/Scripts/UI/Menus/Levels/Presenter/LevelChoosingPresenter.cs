// Created 22.10.2015
// Modified by Александр 01.11.2015 at 17:32

namespace Assets.Scripts.UI.Menus.Levels.Presenter {
    #region References

    #region References

    using System.Linq;
    using Engine.Presenter;
    using State.Levels;
    using State.Levels.Storage;
    using State.Progress.Storage;
    using State.ScenesInteraction.Loaders;
    using UnityEngine;
    using Zenject;

    #endregion

    #endregion

    internal class LevelChoosingPresenter : Presenter<ILevelChoosingMenu> {
        [Inject]
        private ISceneLoader _loader;

        [Inject]
        private IProgressStorage _progressStorage;

        [Inject]
        private ILevelStorage _storage;

        internal void Init(int fromLevel, int toLevel) {
            View.LevelChoosed += OnLevelChoosed;
            View.Levels = _storage.Where(level => level.Number >= fromLevel && level.Number <= toLevel);
        }

        private void OnLevelChoosed(ILevel level) {
            Debug.Log("Choosed level: " + level.Number);
            _progressStorage.SetCurrentLevel(level.Number);
            _loader.GoToScene(Scene.Game);
        }
    }
}