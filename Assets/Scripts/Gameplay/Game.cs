// Created 30.11.2015
// Modified by Александр 16.12.2015 at 21:55

namespace Assets.Scripts.Gameplay {
    #region References

    using System;
    using Engine;
    using GameState.Manager;
    using GameState.StateChangedSources;
    using Heroes;
    using State.Progress;
    using State.ScenesInteraction.Loaders;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    #endregion

    internal class Game : MonoBehaviourBase, IGame, IWinSource {
        [SerializeField]
        private Image _background;

        [Inject]
        private Camera _camera;

        private Hero _hero;

        [Inject]
        private ILevelProgress _progress;

        //[Inject]
        //private IScoreSource _scoreSource;

        [Inject]
        private IGameStateManager _stateManager;

        public ILevelProgress Progress {
            get { return _progress; }
        }

        public LevelWorld World {
            set {
                var world = value;
                world.Camera = _camera;
                world.transform.SetParent(transform);
                _background.sprite = world.Background;
                _hero = world.Hero;
                _hero.Win += OnWin;
            }
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
            //_scoreSource.ScoreChanged += OnScoreChanged;
            _stateManager.Run();
        }

        private void OnScoreChanged(int deltaScore) {
            _progress.Score += deltaScore;
        }
    }
}