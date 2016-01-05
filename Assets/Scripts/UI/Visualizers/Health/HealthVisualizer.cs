// Created 03.11.2015
// Modified by  24.12.2015 at 15:08

namespace Assets.Scripts.UI.Visualizers.Health {
    #region References

    using Bonuses;
    using Engine;
    using Gameplay;
    using State.Levels;
    using State.Progress;
    using State.Progress.Storage;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    #endregion

    internal class HealthVisualizer : MonoBehaviourBase, IHealthVisualizer {
        #region Visible in inspector

        [SerializeField]
        private Image _biologicalProgress;

        [SerializeField]
        private Image _actualProgress;

        [SerializeField]
        private Text _startAge;

        [SerializeField]
        private Text _endAge;

        #endregion

        #region Injected dependencies

        [Inject]
        private IGame _game;

        [Inject]
        private ILevel _currentLevel;

        [Inject]
        private IProgressStorage _progressStorage;

        #endregion

        [PostInject]
        private void PostInject() {
            _startAge.text = "" + _currentLevel.HeroAge;
            _endAge.text = "" + (_currentLevel.HeroAge + 1);
            _game.ProgressChanged += OnProgressChanged;
            _progressStorage.ActualAgeChanged += OnActualAgeChanged;
        }

        protected override void OnDestroy() {
            base.OnDestroy();
            _progressStorage.ActualAgeChanged -= OnActualAgeChanged;
        }

        private void OnActualAgeChanged(object sender, ProgressChangedArgs e) {
            ActualProgress += e.DeltaAge;
        }

        private void OnProgressChanged(object sender, ProgressChangedArgs e) {
            Progress += e.DeltaAge;
        }

        private float Progress {
            get { return _biologicalProgress.fillAmount; }
            set { _biologicalProgress.fillAmount = value; }
        }

        private float ActualProgress {
            get { return _actualProgress.fillAmount; }
            set { _actualProgress.fillAmount = value; }
        }
    }
}