// Created 26.10.2015 
// Modified by Gorbach Alex 05.11.2015 at 12:59

namespace Assets.Scripts.Gameplay.GameState.Manager {
    #region References

    using System.Collections.Generic;
    using StateChangedSources;
    using Consts;
    using Pause;
    using Zenject;

    #endregion

    internal class GameStateManager : IGameStateManager, IPauseHandler {
        [Inject]
        private List<IWinSource> _winSources;

        [Inject]
        private List<IFailSource> _failSources;

        private GameState _state;

        public GameState State {
            get {
                return _state;
            }
            private set {
                if (_state != value) {
                    _state = value;
                    OnStateChanged(_state);
                }
            }
        }

        public event StateChangedDelegate StateChanged;

        public void Pause() {
            State = GameState.Paused;
        }

        public void Resume() {
            State = GameState.Running;
        }

        [PostInject]
        private void PostInject() {
            foreach (var source in _winSources) {
                source.Win += (s) => ChangeState(GameState.Win);
            }

            foreach (var source in _failSources) {
                source.Failed += (s) => ChangeState(GameState.Lose);
            }
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