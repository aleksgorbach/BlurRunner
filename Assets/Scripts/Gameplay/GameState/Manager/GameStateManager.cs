// Created 26.10.2015
// Modified by  22.12.2015 at 10:10

namespace Assets.Scripts.Gameplay.GameState.Manager {
    #region References

    using System.Collections.Generic;
    using Consts;
    using State.Progress;
    using StateChangedSources;
    using Zenject;

    #endregion

    internal class GameStateManager : IGameStateManager {
        private readonly List<IWinSource> _winReasons;

        [Inject]
        private ILevelProgress _progress;

        [Inject(Identifiers.Scores.MinValue)]
        private int _scoreToLose;

        private GameState _state;

        public GameStateManager() {
            _winReasons = new List<IWinSource>();
        }

        public GameState State {
            get { return _state; }
            private set {
                if (_state != value) {
                    _state = value;
                    OnStateChanged(_state);
                }
            }
        }

        public IWinSource Target {
            set {
                value.Win += OnWin;
                _winReasons.Add(value);
            }
        }

        public event StateChangedDelegate StateChanged;

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
            _progress.Changed += OnProgressChanged;
        }

        private void OnWin(IWinSource sender) {
            ChangeState(GameState.Win);
        }

        private void OnProgressChanged(int currentScore) {
            if (currentScore <= _scoreToLose) {
                ChangeState(GameState.Lose);
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