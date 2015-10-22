// Created 22.10.2015
// Modified by Александр 22.10.2015 at 19:59

namespace Assets.Scripts.UI.Visualizers.Stars {
    #region References

    using Engine;
    using Engine.Presenter;
    using Presenter;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class StarsVisualizer : MonoBehaviourBase, IStarsVisualizer {
        private GameObjectFactory<StatedStar> _factory;
        private StarsVisualizerPresenter _presenter;

        [SerializeField]
        private Transform[] _starsContainers;

        public int LevelNumber {
            set { _presenter.Init(value); }
        }

        public int Stars {
            set {
                for (var i = 0; i < _starsContainers.Length; i++) {
                    var star = _factory.Create();
                    var transf = star.transform as RectTransform;
                    transf.SetParent(_starsContainers[i]);
                    transf.anchoredPosition = Vector2.zero;
                    transf.offsetMax = transf.offsetMin = Vector2.zero;
                    transf.localRotation = Quaternion.identity;
                    star.State = i < value;
                }
            }
        }

        [PostInject]
        private void Inject(PresenterFactory presenterFactory, StarFactory factory) {
            _presenter = presenterFactory.Create<StarsVisualizerPresenter, IStarsVisualizer>(this);
            _factory = factory;
        }
    }
}