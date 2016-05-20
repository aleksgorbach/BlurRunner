// Created 03.11.2015
// Modified by  28.01.2016 at 12:08

namespace Assets.Scripts.UI.Visualizers.Age {
    #region References

    using Engine;
    using State.Progress.Storage;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    #endregion

    internal class AgeVisualizer : MonoBehaviourBase, IAgeVisualizer {
        private const int MAX_AGE = 10;
        private const float MAX_GAP = 1f;

        #region Visible in inspector

        [SerializeField]
        private Slider _biologicalProgress;

        [SerializeField]
        private Slider _actualProgress;

        #endregion

        #region Injected dependencies

        [Inject]
        private IProgressStorage _progressStorage;

        #endregion

        protected override void Start() {
            base.Start();
            _biologicalProgress.maxValue = MAX_AGE;
            _actualProgress.maxValue = MAX_AGE;
        }

        private void FixedUpdate() {
            ActualProgress = _progressStorage.ActualAge;
            Progress = _progressStorage.CurrentAge;
        }

        private float Progress {
            get { return _biologicalProgress.value; }
            set { _biologicalProgress.value = value; }
        }

        private float ActualProgress {
            set {
                _actualProgress.value = value;
            }
        }
    }
}