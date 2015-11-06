// Created 26.10.2015 
// Modified by Gorbach Alex 06.11.2015 at 8:36

namespace Assets.Scripts.Gameplay.GameState.Manager {
    #region References

    using System.Collections.Generic;
    using StateChangedSources;
    using Consts;
    using Zenject;

    #endregion

    internal class GameStateManager : IGameStateManager {
        [Inject]
        private List<IWinSource> _winSources;

        //[Inject]
        //private List<IFailSource> _failSources;

        [Inject]
        private List<IPauseSource> _pauseSources;

        [Inject]
        private List<IRunSource> _runSources;

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

        [PostInject]
        private void PostInject() {
            foreach (var source in _winSources) {
                source.Win += (s) => ChangeState(GameState.Win);
            }

            //foreach (var source in _failSources) {
            //    source.Failed += (s) => ChangeState(GameState.Lose);
            //}

            foreach (var source in _pauseSources) {
                source.Pause += () => ChangeState(GameState.Paused);
            }
            foreach (var source in _runSources) {
                source.Run += () => ChangeState(GameState.Running);
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