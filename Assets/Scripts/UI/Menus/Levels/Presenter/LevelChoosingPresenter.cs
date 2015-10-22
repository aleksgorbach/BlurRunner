// Created 20.10.2015 
// Modified by Gorbach Alex 22.10.2015 at 15:11

namespace Assets.Scripts.UI.Menus.Levels.Presenter {
    #region References

    #region References

    using Assets.Scripts.State.ScenesInteraction.Loaders;
    using State.Levels;
    using Engine.Presenter;
    using State.Levels.Storage;
    using UnityEngine;
    using Zenject;

    #endregion

    #endregion

    internal class LevelChoosingPresenter : Presenter<ILevelChoosingMenu> {
        private ILevelStorage _storage;
        private ISceneLoader _loader;

        internal void Init(int fromLevel, int toLevel) {
            View.LevelChoosed += OnLevelChoosed;
            View.Levels = _storage.Get(fromLevel, toLevel);
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