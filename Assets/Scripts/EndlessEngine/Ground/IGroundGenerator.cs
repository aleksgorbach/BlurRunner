// Created 02.11.2015
// Modified by Александр 02.11.2015 at 19:23

namespace Assets.Scripts.EndlessEngine.Ground {
    #region References

    using UI;

    #endregion

    internal delegate void BlockEventDelegate(GroundBlock block);

    internal interface IGroundGenerator {
        /// <summary>
        /// Raised when new block has to be created
        /// </summary>
        event BlockEventDelegate BlockCreated;

        /// <summary>
        /// Raised when block makes invisible and has to be removed
        /// </summary>
        event BlockEventDelegate BlockRemoved;
    }
}