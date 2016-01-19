// Created 20.10.2015
// Modified by  19.01.2016 at 15:59

namespace Assets.Scripts.Gameplay {
    #region References

    using System;
    using System.Collections.Generic;
    using Engine;
    using Engine.Camera;
    using Engine.Extensions;
    using Events;
    using GameState.Manager;
    using Heroes;
    using State;
    using State.Levels.Storage;
    using State.Progress.Storage;
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
        private ILevelStorage _levelStorage;

        [Inject]
        private IGameStateManager _stateManager;

        [Inject]
        private IProgressStorage _progressStorage;

        [Inject]
        private List<IGameStartedHandler> _gameStartedHandlers;

        [Inject]
        private List<IGameLoopUpdatable> _updatables;

        #endregion

        private Hero _hero;
        private float _levelLength;
        private float _progress;

        #region Interface

        #region Events

        public event EventHandler<GameStartedEventArgs> Started;
        public event EventHandler<GameFinishedEventArgs> Finished;
        public event EventHandler<GameWinEventArgs> Win;
        public event EventHandler<GameLoseEventArgs> Lose;
        public event EventHandler<GameProgressChangedArgs> ProgressChanged;

        #endregion

        public float Progress {
            get { return _progress; }
            private set {
                var prev = Progress;
                _progress = value;
                ProgressChanged.SafeInvoke(this, new GameProgressChangedArgs(_progress, _progress - prev));
            }
        }

        public float PerfectLevelTime {
            get { return _levelLength/_hero.Speed; }
        }

        private void FixedUpdate() {
            if (_hero == null) {
                return;
            }
            Progress = _hero.Position.x/_levelLength;
        }

        #endregion

        protected override void Awake() {
            base.Awake();
            _worldLoader.WorldLoaded += OnWorldLoaded;
        }

        protected override void Update() {
            base.Update();
            if (_stateManager.State == Consts.GameState.Running) {
                foreach (var updatable in _updatables) {
                    updatable.Update(this);
                }
            }
        }

        private void OnStateChanged(object sender, GameStateChangedArgs e) {
            switch (e.State) {
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
            _progressStorage.Save();
            Win.SafeInvoke(this, new GameWinEventArgs());
        }

        private void OnLose() {
            Lose.SafeInvoke(this, new GameLoseEventArgs());
        }


        [PostInject]
        private void PostInject() {
            _stateManager.StateChanged += OnStateChanged;
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
            _levelLength = world.Length;
            _camera.SetTarget(_hero.transform);
            OnGameReady();
        }

        private void OnGameReady() {
            Started.SafeInvoke(this, new GameStartedEventArgs(_levelStorage.CurrentLevel, _hero));
            _stateManager.Run();
            foreach (var gameStartedHandler in _gameStartedHandlers) {
                gameStartedHandler.OnGameStarted(this);
            }
        }
    }
}