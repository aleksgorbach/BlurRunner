// Created 15.10.2015
// Modified by Александр 25.10.2015 at 18:12

namespace Assets.Scripts.EndlessEngine.Ground.Generators {
    #region References

    using UI;

    #endregion

    internal interface IGroundGenerator {
        //GroundBlockUI GetCompatibleBlock(GroundBlockUI origin, BlockPosition position = BlockPosition.Left);
        //void ReturnBlock(GroundBlockUI block);

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