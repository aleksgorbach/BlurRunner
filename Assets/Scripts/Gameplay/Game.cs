// Created 30.11.2015
// Modified by Александр 06.12.2015 at 18:37

namespace Assets.Scripts.Gameplay {
    #region References

    using System;
    using EndlessEngine.Levels;
    using Engine;
    using GameState.Manager;
    using GameState.StateChangedSources;
    using Heroes;
    using State.Levels;
    using State.Progress;
    using State.Progress.Score;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    #endregion

    internal class Game : MonoBehaviourBase, IGame, IWinSource {
        [SerializeField]
        private Image _background;

        private Hero _hero;

        [SerializeField]
        private LevelGenerator _levelGenerator;

        [Inject]
        private ILevelProgress _progress;

        [Inject]
        private IScoreSource _scoreSource;

        [Inject]
        private IGameStateManager _stateManager;

        public ILevelProgress Progress {
            get { return _progress; }
        }

        public void StartLevel(ILevel level) {
            //_level = level;
            _background.sprite = level.Background;
            //_heroSpawner.Sprite = level.Startpoint;
            _hero = _levelGenerator.Generate(level);
            _hero.Win += OnWin;
        }

        public event Action<IWinSource> Win;

        private void OnStateChanged(Consts.GameState state) {
            switch (state) {
                case Consts.GameState.Running:
                    Run();
                    break;
                case Consts.GameState.Paused:
                    Pause();
                    break;
                case Consts.GameState.Lose:
                    OnDie();
                    break;
                case Consts.GameState.Win:
                    OnWin();
                    break;
            }
        }

        private void Pause() {
            Time.timeScale = 0;
        }

        private void Run() {
            Time.timeScale = 1;
        }

        private void OnDie() {
            _hero.Kill();
        }

        private void OnWin() {
            _hero.Congratulate();
        }


        private void OnWin(IWinSource winSource) {
            var handler = Win;
            if (handler != null) {
                handler.Invoke(winSource);
            }
        }

        [PostInject]
        private void PostInject() {
            _stateManager.StateChanged += OnStateChanged;
            _scoreSource.ScoreChanged += OnScoreChanged;
            _stateManager.Run();
        }

        private void OnScoreChanged(int deltaScore) {
            _progress.Score += deltaScore;
        }
    }
}