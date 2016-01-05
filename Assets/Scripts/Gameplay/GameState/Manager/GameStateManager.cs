// Created 26.10.2015
// Modified by  28.12.2015 at 10:42

namespace Assets.Scripts.Gameplay.GameState.Manager {
    #region References

    using Consts;
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

        public event StateChangedDelegate StateChanged;

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

        private void Win(IWinSource sender) {
            ChangeState(GameState.Win);
        }

        private void Lose(object sender, Hero.HeroEventArgs heroEventArgs) {
            ChangeState(GameState.Lose);
        }

        private void ChangeState(GameState to) {
            State = to;
        }

        private void OnStateChanged(GameState state) {
            var handler = StateChanged;
            if (handler != null) {
                handler.Invoke(state);
            }
        }
    }
}