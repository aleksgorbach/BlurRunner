// Created 22.10.2015
// Modified by Александр 27.10.2015 at 20:43

namespace Assets.Scripts.UI.Menus.Levels.Presenter {
    #region References

    #region References

    using System.Linq;
    using Engine.Presenter;
    using State.Levels;
    using State.Levels.Storage;
    using State.ScenesInteraction.Loaders;
    using UnityEngine;
    using Zenject;

    #endregion

    #endregion

    internal class LevelChoosingPresenter : Presenter<ILevelChoosingMenu> {
        private ISceneLoader _loader;
        private ILevelStorage _storage;

        internal void Init(int fromLevel, int toLevel) {
            View.LevelChoosed += OnLevelChoosed;
            View.Levels = _storage.Where(level => level.Number >= fromLevel && level.Number <= toLevel);
        }

        private void OnLevelChoosed(ILevel level) {
            Debug.Log("Choosed level: " + level.Number);
            _loader.GoToNextScene();
        }

        [PostInject]
        private void Init(ILevelStorage storage, ISceneLoader sceneLoader) {
            _storage = storage;
            _loader = sceneLoader;
        }
    }
}