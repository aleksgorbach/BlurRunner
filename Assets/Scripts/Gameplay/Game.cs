// Created 20.10.2015
// Modified by  24.12.2015 at 11:30

namespace Assets.Scripts.Gameplay {
    #region References

    using System;
    using Consts;
    using Engine;
    using Engine.Camera;
    using GameState.Manager;
    using Heroes;
    using State.Progress;
    using State.ScenesInteraction.Loaders;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    #endregion

    internal class Game : MonoBehaviourBase, IGame {
        #region Visible in inspector

        [SerializeField]
        private Image _background;

        [SerializeField]
        private SmoothFollow2D _camera;

        [SerializeField]
        private Camera _foregroundCamera;

        [SerializeField]
        private WorldLoader _worldLoader;

        #endregion

        #region Injected dependencies

        [Inject]
        private IInstantiator _container;

        [Inject(Identifiers.Levels.CurrentLevel)]
        private int _levelNumber;

        [Inject]
        private ILevelProgress _progress;

        [Inject]
        private IGameStateManager _stateManager;

        #endregion

        private Hero _hero;

        #region Interface

        public ILevelProgress Progress {
            get { return _progress; }
        }

        #region Events

        public event EventHandler<WorldLoader.WorldLoadedEventArgs> WorldLoaded;
        public event EventHandler<Hero.HeroSpawnedEventArgs> HeroSpawned;

        #endregion

        #endregion

        private void OnStateChanged(Consts.GameState state) {
            switch (state) {
                case Consts.GameState.Running:
                    Run();
                    break;
                case Consts.GameState.Paused:
                    Pause();
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


        private void OnWin() {
            _hero.Congratulate();
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
            world.ForegroundCamera = _camera.Camera;
            world.BackgroundCamera = _foregroundCamera;
            world.transform.SetParent(transform);
            world.transform.SetAsFirstSibling();
            _background.sprite = world.Background;
            _hero = _container.InstantiatePrefabForComponent<Hero>(world.HeroPrefab.gameObject);
            _hero.transform.SetParent(world.StartPoint);
            _hero.transform.localPosition = Vector3.zero;
            _camera.SetTarget(_hero.transform);
            var handler = WorldLoaded;
            if (handler != null) {
                handler(this, new WorldLoader.WorldLoadedEventArgs(world));
            }
            OnHeroSpawned(_hero);
        }

        private void OnHeroSpawned(Hero hero) {
            var handler = HeroSpawned;
            if (handler != null) {
                handler.Invoke(this, new Hero.HeroSpawnedEventArgs(hero));
            }
        }

        private void OnScoreChanged(int deltaScore) {
            _progress.Score += deltaScore;
        }
    }
}