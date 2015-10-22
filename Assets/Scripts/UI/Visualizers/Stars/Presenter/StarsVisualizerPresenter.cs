// Created 22.10.2015 
// Modified by Gorbach Alex 22.10.2015 at 13:16

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
            View.Stars = progress != null ? progress.Stars : 0;
        }

        [PostInject]
        private void Init(IProgressStorage progressStorage) {
            _storage = progressStorage;
        }
    }
}