// Created 25.10.2015
// Modified by Александр 25.10.2015 at 10:54

namespace Assets.Scripts.Gameplay.GameState.Pause {
    internal interface IPauseHandler {
        /// <summary>
        /// Called when game paused
        /// </summary>
        void Pause();
        /// <summary>
        /// Called when game resumed after pause
        /// </summary>
        void Resume();
    }
}