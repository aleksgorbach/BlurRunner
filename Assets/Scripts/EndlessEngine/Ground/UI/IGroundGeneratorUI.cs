// Created 25.10.2015
// Modified by Александр 25.10.2015 at 18:11

namespace Assets.Scripts.EndlessEngine.Ground.UI {
    internal delegate void BlockEventDelegate(GroundBlockUI block);

    internal interface IGroundGeneratorUI {
        /// <summary>
        /// Raised when new block has to be created
        /// </summary>
        event BlockEventDelegate NewBlockNeed;

        /// <summary>
        /// Raised when block makes invisible and has to be removed
        /// </summary>
        event BlockEventDelegate RemoveBlockNeeded;

        /// <summary>
        /// Adds block to the ground
        /// </summary>
        /// <param name="groundBlock">Created block</param>
        void AddBlock(GroundBlockUI groundBlock);

        /// <summary>
        /// Removes the last block from the ground
        /// </summary>
        void RemoveBlock();
    }
}