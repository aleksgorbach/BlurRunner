// Created 26.11.2015
// Modified by Александр 26.11.2015 at 21:12

namespace Assets.Scripts.Gameplay {
    #region References

    using System;
    using EndlessEngine.Endpoints;
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

        [SerializeField]
        private ObjectAnchor _cameraAnchor;

        [Inject]
        private IInstantiator _container;

        private Hero _hero;

        [SerializeField]
        private HeroSpawner _heroSpawner;

        private bool _isPaused;
        //private ILevel _level;

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
            //_background.sprite = level.Background;
            //_heroSpawner.Sprite = level.Startpoint;
            _levelGenerator.Generated += OnLevelGenerated;
            _levelGenerator.Generate(level);
        }

        public event Action<IWinSource> Win;

        private void OnLevelGenerated() {
            //todo стартовать игру
            throw new NotImplementedException();
        }

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
            //_hero = _container.InstantiatePrefabForComponent<Hero>(_level.Hero.gameObject);
            //_hero.transform.SetParent(_heroSpawner.Container);
            //_hero.transform.localPosition = Vector3.zero;
            //_cameraAnchor.SetTarget(_hero.transform);
            //_hero.Destination = _level.Length;
            //_hero.Win += OnWin;
            _scoreSource.ScoreChanged += OnScoreChanged;
            _stateManager.Run();
        }

        private void OnScoreChanged(int deltaScore) {
            _progress.Score += deltaScore;
        }
    }
}