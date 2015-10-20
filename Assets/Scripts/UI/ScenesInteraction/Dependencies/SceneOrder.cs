// Created 20.10.2015
// Modified by Александр 20.10.2015 at 20:54

namespace Assets.Scripts.UI.ScenesInteraction.Dependencies {
    #region References

    using System.Collections.Generic;

    #endregion

    internal class SceneOrder : ISceneOrder {
        private readonly IList<string> _scenes;
        private int _currentSceneIndex;

        public SceneOrder() {
            _scenes = new List<string> {"LevelChooseScene", "GameScene"};
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