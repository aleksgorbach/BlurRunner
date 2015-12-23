// Created 20.10.2015
// Modified by  22.12.2015 at 10:32

namespace Assets.Scripts.Gameplay {
    #region References

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
        [SerializeField]
        private Image _background;

        [SerializeField]
        private SmoothFollow2D _camera;

        //[Inject]
        //private IScoreSource _scoreSource;

        [Inject]
        private IInstantiator _container;

        [SerializeField]
        private Camera _foregroundCamera;

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
            _stateManager.Target = world.EndPoint;
        }

        private void OnScoreChanged(int deltaScore) {
            _progress.Score += deltaScore;
        }
    }
}