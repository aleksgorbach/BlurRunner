// Created 20.10.2015
// Modified by  28.12.2015 at 10:42

namespace Assets.Scripts.Gameplay {
    #region References

    using System;
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

        public event EventHandler<Hero.HeroSpawnedEventArgs> HeroSpawned;

        #endregion

        #endregion

        protected override void Awake() {
            base.Awake();
            _worldLoader.WorldLoaded += OnWorldLoaded;
        }

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
            _stateManager.Run();
        }

        private void OnWorldLoaded(object sender, WorldLoader.WorldLoadedEventArgs args) {
            // инициализация уровня из world
            var world = args.World;
            world.ForegroundCamera = _camera.Camera;
            world.BackgroundCamera = _foregroundCamera;
            world.transform.SetParent(transform);
            world.transform.SetAsFirstSibling();
            _background.sprite = world.Background;
            _hero = _container.InstantiatePrefabForComponent<Hero>(world.HeroPrefab.gameObject);
            _hero.transform.SetParent(world.StartPoint);
            _hero.transform.localPosition = Vector3.zero;
            _camera.SetTarget(_hero.transform);
            OnHeroSpawned(_hero);
        }

        private void OnHeroSpawned(Hero hero) {
            var handler = HeroSpawned;
            if (handler != null) {
                handler.Invoke(this, new Hero.HeroSpawnedEventArgs(hero));
            }
        }
    }
}