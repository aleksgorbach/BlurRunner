// Created 26.10.2015 
// Modified by Gorbach Alex 26.10.2015 at 13:42

namespace Assets.Scripts.EndlessEngine.Ground {
    #region References

    using UI;

    #endregion

    internal interface IGroundGenerator {
        /// <summary>
        /// Raised when new block was created
        /// </summary>
        event BlockEventDelegate BlockCreated;

        /// <summary>
        /// Raised when block was removed from the ground
        /// </summary>
        event BlockEventDelegate BlockRemoved;
    }
}