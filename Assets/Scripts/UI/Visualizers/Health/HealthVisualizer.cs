// Created 03.11.2015
// Modified by  19.01.2016 at 15:37

namespace Assets.Scripts.UI.Visualizers.Health {
    #region References

    using Bonuses;
    using Engine;
    using Gameplay;
    using Gameplay.Events;
    using State.Levels;
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

        private float _levelStartAge;

        [PostInject]
        private void PostInject() {
            _startAge.text = "" + _currentLevel.HeroAge;
            _endAge.text = "" + (_currentLevel.HeroAge + 1);
            _levelStartAge = _currentLevel.HeroAge;
            _game.ProgressChanged += OnProgressChanged;
        }

        private void OnProgressChanged(object sender, GameProgressChangedArgs e) {
            //Progress = e.Progress;
        }

        private void FixedUpdate() {
            ActualProgress = _progressStorage.ActualAge - _levelStartAge;
            Progress = _progressStorage.CurrentAge/10f;
        }

        private float Progress {
            set { _biologicalProgress.fillAmount = value; }
        }

        private float ActualProgress {
            set { _actualProgress.fillAmount = value; }
        }
    }
}