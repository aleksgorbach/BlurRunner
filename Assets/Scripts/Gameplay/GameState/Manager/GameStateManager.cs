// Created 26.10.2015
// Modified by  18.12.2015 at 16:30

namespace Assets.Scripts.Gameplay.GameState.Manager {
    #region References

    using System;
    using System.Collections.Generic;
    using Consts;
    using State.Progress;
    using StateChangedSources;
    using Zenject;

    #endregion

    internal class GameStateManager : IGameStateManager {
        [Inject]
        private ILevelProgress _progress;

        [Inject(Identifiers.Scores.MinValue)]
        private int _scoreToLose;

        private GameState _state;

        // todo в какой-то момент (update?) проходиться по списку и проверять на выигрыш
        private List<Func<bool>> _winReasons;

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

        public void AddWinReason(Func<bool> reason) {
            _winReasons.Add(reason);
        }

        [PostInject]
        private void PostInject() {
            _progress.Changed += OnProgressChanged;
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