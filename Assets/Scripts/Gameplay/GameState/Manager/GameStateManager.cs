// Created 26.10.2015
// Modified by  24.12.2015 at 11:30

namespace Assets.Scripts.Gameplay.GameState.Manager {
    #region References

    using Consts;
    using Heroes;
    using State.ScenesInteraction.Loaders;
    using StateChangedSources;
    using Zenject;

    #endregion

    internal class GameStateManager : IGameStateManager {
        #region Injected dependencies

        [Inject]
        private IGame _game;

        #endregion

        private GameState _state;

        #region

        public GameState State {
            get { return _state; }
            private set {
                if (_state != value) {
                    _state = value;
                    OnStateChanged(_state);
                }
            }
        }

        public event StateChangedDelegate StateChanged;

        #endregion

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

        [PostInject]
        private void PostInject() {
            _game.WorldLoaded += OnWorldLoaded;
            _game.HeroSpawned += OnHeroSpawned;
        }

        private void OnWorldLoaded(object sender, WorldLoader.WorldLoadedEventArgs e) {
            e.World.EndPoint.Win += Win;
        }

        private void OnHeroSpawned(object sender, Hero.HeroSpawnedEventArgs e) {
            e.Hero.Died += Lose;
        }

        private void Win(IWinSource sender) {
            ChangeState(GameState.Win);
        }

        private void Lose() {
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