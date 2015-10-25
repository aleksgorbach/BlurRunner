// Created 22.10.2015
// Modified by Александр 25.10.2015 at 11:03

namespace Assets.Scripts.Gameplay {
    #region References

    using System;
    using System.Collections.Generic;
    using GameState.Manager;
    using GameState.Pause;

    #endregion

    internal class Game : IGame {
        private readonly List<IPauseHandler> _pauseHandlers;
        private readonly IGameStateManager _stateManager;

        private bool _isPaused;

        public Game(IGameStateManager stateManager, List<IPauseHandler> pauseHandlers) {
            _stateManager = stateManager;
            _pauseHandlers = pauseHandlers;
            _stateManager.StateChanged += OnStateChanged;
        }

        private void OnStateChanged(Consts.GameState state) {
            switch (state) {
                case Consts.GameState.NotStarted:
                    break;
                case Consts.GameState.Running:
                    if (_isPaused) {
                        foreach (var handler in _pauseHandlers) {
                            handler.Resume();
                        }
                        _isPaused = false;
                    }
                    break;
                case Consts.GameState.Win:
                    break;
                case Consts.GameState.Lose:
                    break;
                case Consts.GameState.Paused:
                    foreach (var handler in _pauseHandlers) {
                        handler.Pause();
                    }
                    _isPaused = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(state.ToString(), state, null);
            }
        }
    }
}