// Created 20.10.2015
// Modified by  28.12.2015 at 10:42

namespace Assets.Scripts.Gameplay {
    #region References

    using System;
    using Engine;
    using Engine.Camera;
    using Engine.Extensions;
    using Events;
    using GameState.Manager;
    using Heroes;
    using State.Levels.Storage;
    using State.Progress;
    using State.Progress.Storage;
    using State.ScenesInteraction.Loaders;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    #endregion

    internal class Game : MonoBehaviourBase, IGame {
        private const float TOLERANCE = 0.01f;

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
        private ILevelStorage _levelStorage;

        [Inject]
        private IGameStateManager _stateManager;

        [Inject]
        private IProgressStorage _progressStorage;

        #endregion

        private Hero _hero;
        private float _levelLength;

        #region Interface

        #region Events

        public event EventHandler<GameStartedEventArgs> Started;
        public event EventHandler<GameFinishedEventArgs> Finished;
        public event EventHandler<GameWinEventArgs> Win;
        public event EventHandler<GameLoseEventArgs> Lose;
        public event EventHandler<ProgressChangedArgs> ProgressChanged;

        #endregion

        public float Progress { get; private set; }

        private float _prevProgress;

        private void FixedUpdate() {
            if (_hero == null) {
                return;
            }
            _prevProgress = Progress;
            Progress = _hero.Position.x/_levelLength;
            var delta = Math.Abs(Progress - _prevProgress);
            ProgressChanged.SafeInvoke(this, new ProgressChangedArgs(delta));
        }

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
                case Consts.GameState.Lose:
                    OnLose();
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
            _hero.Win();
            Win.SafeInvoke(this, new GameWinEventArgs());
        }

        private void OnLose() {
            Lose.SafeInvoke(this, new GameLoseEventArgs());
        }


        [PostInject]
        private void PostInject() {
            _stateManager.StateChanged += OnStateChanged;
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
            _progressStorage.CurrentAge = _levelStorage.CurrentLevel.HeroAge;
            _levelLength = world.Length;
            _camera.SetTarget(_hero.transform);
            OnGameReady();
        }

        private void OnGameReady() {
            Started.SafeInvoke(this, new GameStartedEventArgs(_levelStorage.CurrentLevel, _hero));
        }
    }
}