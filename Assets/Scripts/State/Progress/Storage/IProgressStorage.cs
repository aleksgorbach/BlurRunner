// Created 09.11.2015 
// Modified by Gorbach Alex 09.11.2015 at 17:15

namespace Assets.Scripts.State.Progress.Storage {
    internal interface IProgressStorage {
        /// <summary>
        /// Returns progress of given level
        /// </summary>
        /// <param name="levelNumber">Level number</param>
        /// <returns></returns>
        ILevelProgress this[int levelNumber] { get; }

        /// <summary>
        /// Returns current level progress
        /// </summary>
        ILevelProgress CurrentLevelProgress { get; }

        /// <summary>
        /// Sets current level
        /// </summary>
        /// <param name="number">Level number to make current</param>
        void SetCurrentLevel(int number);
    }
}