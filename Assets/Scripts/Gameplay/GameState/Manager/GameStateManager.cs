// Created 26.10.2015
// Modified by  14.01.2016 at 9:06

namespace Assets.Scripts.Gameplay.GameState.Manager {
    #region References

    using System;
    using Consts;
    using Engine.Extensions;
    using Events;
    using Heroes;
    using State.ScenesInteraction.Loaders;
    using StateChangedSources;
    using Zenject;

    #endregion

    internal class GameStateManager : IGameStateManager {
        #region Injected dependencies

        [Inject]
        private IGame _game;

        [Inject]
        private IWorldLoader _worldLoader;

        #endregion

        private GameState _state;

        #region Interface

        public GameState State {
            get { return _state; }
            private set {
                if (_state != value) {
                    _state = value;
                    OnStateChanged(_state);
                }
            }
        }

        public void Pause() {
            if (State == GameState.Running) {
                ChangeState(GameState.Paused);
            }
        }

        public void Resume() {
            if (State == GameState.Paused) {
                ChangeState(GameState.Running);
            }
        }

        public void Run() {
            ChangeState(GameState.Running);
        }

        public event EventHandler<GameStateChangedArgs> StateChanged;

        #endregion

        [PostInject]
        private void PostInject() {
            _worldLoader.WorldLoaded += OnWorldLoaded;
            _game.Started += OnGameStarted;
        }

        private void OnWorldLoaded(object sender, WorldLoader.WorldLoadedEventArgs e) {
            e.World.EndPoint.Win += Win;
        }

        private void OnGameStarted(object sender, GameStartedEventArgs e) {
            e.Hero.Died += Lose;
        }

        private void Win(object o, WinSourceArgs e) {
            ChangeState(GameState.Win);
        }

        private void Lose(object sender, Hero.HeroEventArgs e) {
            ChangeState(GameState.Lose);
        }

        private void ChangeState(GameState to) {
            State = to;
        }

        private void OnStateChanged(GameState state) {
            StateChanged.SafeInvoke(this, new GameStateChangedArgs(state));
        }
    }
}