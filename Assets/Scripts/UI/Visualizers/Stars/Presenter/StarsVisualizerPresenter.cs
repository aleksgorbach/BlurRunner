// Created 21.10.2015
// Modified by Александр 21.10.2015 at 20:29

namespace Assets.Scripts.UI.Visualizers.Stars.Presenter {
    #region References

    using Engine.Presenter;
    using State.Progress.Storage;
    using Zenject;

    #endregion

    internal class StarsVisualizerPresenter : Presenter<IStarsVisualizer> {
        private IProgressStorage _storage;

        public void Init(int levelNumber) {
            var progress = _storage[levelNumber];
            View.Stars = progress.Stars;
        }

        [PostInject]
        private void Init(IProgressStorage progressStorage) {
            _storage = progressStorage;
        }
    }
}