// Created 20.10.2015 
// Modified by Gorbach Alex 12.11.2015 at 12:22

namespace Assets.Scripts.Gameplay {
    #region References

    using System;
    using Assets.Scripts.State.Progress.Score;
    using EndlessEngine;
    using Engine;
    using GameState.Manager;
    using GameState.StateChangedSources;
    using Heroes;
    using State.Levels;
    using State.Progress;
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

        [SerializeField]
        private AbstractGenerator[] _generators;

        private Hero _hero;

        [SerializeField]
        private Transform _heroSpawner;

        private bool _isPaused;
        private ILevel _level;

        [Inject]
        private ILevelProgress _progress;

        [Inject]
        private IGameStateManager _stateManager;

        [Inject]
        private IScoreSource _scoreSource;

        public ILevelProgress Progress {
            get {
                return _progress;
            }
        }

        public void StartLevel(ILevel level) {
            _level = level;
            _background.sprite = level.Background;
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
                    Pause();
                    break;
                case Consts.GameState.Win:
                    StopGenerating();
                    break;
            }
        }

        private void Pause() {
            Time.timeScale = 0;
        }

        private void Run() {
            Time.timeScale = 1;
        }

        private void StopGenerating() {
            foreach (var generator in _generators) {
                generator.Stop();
            }
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
            _hero = _container.InstantiatePrefabForComponent<Hero>(_level.Hero.gameObject);
            _hero.transform.SetParent(_heroSpawner);
            _hero.transform.localPosition = Vector3.zero;
            _cameraAnchor.SetTarget(_hero.transform);
            _hero.Destination = _level.Length;
            _hero.Win += OnWin;
            _scoreSource.ScoreChanged += OnScoreChanged;
        }

        private void OnScoreChanged(int deltaScore) {
            _progress.Score += deltaScore;
        }
    }
}