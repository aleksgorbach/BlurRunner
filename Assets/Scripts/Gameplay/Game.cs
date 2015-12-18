// Created 20.10.2015
// Modified by  18.12.2015 at 16:36

namespace Assets.Scripts.Gameplay {
    #region References

    using System;
    using Consts;
    using Engine;
    using Engine.Camera;
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

        [SerializeField]
        private SmoothFollow2D _camera;

        //[Inject]
        //private IScoreSource _scoreSource;

        [Inject]
        private IInstantiator _container;

        private Hero _hero;

        [Inject(Identifiers.Levels.CurrentLevel)]
        private int _levelNumber;

        [Inject]
        private ILevelProgress _progress;

        [Inject]
        private IGameStateManager _stateManager;

        [SerializeField]
        private WorldLoader _worldLoader;

        public ILevelProgress Progress {
            get { return _progress; }
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
            _worldLoader.Load(_levelNumber, OnWorldLoaded);
            _stateManager.Run();
        }

        private void OnWorldLoaded(LevelWorld world) {
            // инициализация уровня из world
            world.Camera = _camera.Camera;
            world.transform.SetParent(transform);
            world.transform.SetAsFirstSibling();
            _background.sprite = world.Background;
            _hero = _container.InstantiatePrefabForComponent<Hero>(world.HeroPrefab.gameObject);
            _hero.transform.SetParent(world.StartPoint);
            _hero.transform.localPosition = Vector3.zero;
            _camera.SetTarget(_hero.transform);
        }

        private void OnScoreChanged(int deltaScore) {
            _progress.Score += deltaScore;
        }
    }
}