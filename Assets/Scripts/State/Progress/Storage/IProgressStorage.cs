// Created 22.10.2015
// Modified by  19.11.2015 at 14:59

namespace Assets.Scripts.State.Progress.Storage {
    internal interface IProgressStorage {
        /// <summary>
        /// Returns progress of given level
        /// </summary>
        /// <param name="levelNumber">Level number</param>
        /// <returns></returns>
        //ILevelProgress this[int levelNumber] { get; }
        /// <summary>
        /// Returns current level
        /// </summary>
        int CurrentLevel { get; }

        /// <summary>
        /// Sets current level
        /// </summary>
        /// <param name="number">Level number to make current</param>
        void SetCurrentLevel(int number);
    }
}