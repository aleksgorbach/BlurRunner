// Created 22.10.2015
// Modified by Александр 22.10.2015 at 21:39

namespace Assets.Scripts.State.ScenesInteraction.Dependencies {
    #region References

    using System.Collections.Generic;

    #endregion

    internal class SceneOrder : ISceneOrder {
        private readonly IList<string> _scenes;
        private int _currentSceneIndex;

        public SceneOrder() {
            _scenes = new List<string> {"LogoScene", "LevelChooseScene", "GameScene"};
            _currentSceneIndex = 0;
        }

        public string GetNextScene() {
            if (_currentSceneIndex < _scenes.Count) {
                _currentSceneIndex++;
                return _scenes[_currentSceneIndex];
            }
            return null;
        }

        public string GetPreviousScene() {
            if (_currentSceneIndex > 0) {
                _currentSceneIndex--;
                return _scenes[_currentSceneIndex];
            }
            return null;
        }
    }
}