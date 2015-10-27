// Created 24.10.2015
// Modified by Александр 27.10.2015 at 21:29

namespace Assets.Scripts.Gameplay.GameState.Manager {
    #region References

    using Consts;
    using Pause;

    #endregion

    internal class GameStateManager : IGameStateManager, IPauseHandler {
        private GameState _state;

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

        public void Pause() {
            State = GameState.Paused;
        }

        public void Resume() {
            State = GameState.Running;
        }

        private void OnStateChanged(GameState state) {
            var handler = StateChanged;
            if (handler != null) {
                handler.Invoke(state);
            }
        }
    }
}