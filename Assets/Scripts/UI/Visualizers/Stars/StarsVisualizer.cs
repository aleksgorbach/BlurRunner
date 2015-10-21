// Created 21.10.2015
// Modified by Александр 21.10.2015 at 20:32

namespace Assets.Scripts.UI.Visualizers.Stars {
    #region References

    using Engine;
    using Engine.Presenter;
    using Presenter;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    #endregion

    internal class StarsVisualizer : MonoBehaviourBase, IStarsVisualizer {
        private int _levelNumber;
        //todo обернуть звезды в отдельные айтемы
        [SerializeField]
        private Image[] _starsImages;

        public int Stars {
            set {
                for (var i = 0; i < _starsImages.Length; i++) {
                    _starsImages[i].gameObject.SetActive(i < value);
                }
            }
        }

        [PostInject]
        private void Inject(PresenterFactory presenterFactory) {
            var presenter = presenterFactory.Create<StarsVisualizerPresenter, IStarsVisualizer>(this);
            presenter.Init(_levelNumber);
        }
    }
}