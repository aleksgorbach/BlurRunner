// Created 24.10.2015
// Modified by Александр 24.10.2015 at 21:53

namespace Assets.Scripts.Gameplay.GameState.Manager {
    using Consts;

    internal class GameStateManager : IGameStateManager {
        public GameState State { get; private set; }
        public event StateChangedDelegate StateChanged;

        private void OnStateChanged(GameState state) {
            var handler = StateChanged;
            if (handler != null) {
                handler.Invoke(state);
            }
        }
    }
}