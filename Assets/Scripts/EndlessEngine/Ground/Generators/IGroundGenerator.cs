using Assets.Scripts.EndlessEngine.Ground.UI;

namespace Assets.Scripts.EndlessEngine.Ground.Generators {
    internal enum BlockPosition {
        Left,
        Right
    }

    internal interface IGroundGenerator {
        GroundBlockUI GetCompatibleBlock(GroundBlockUI origin, BlockPosition position = BlockPosition.Left);
    }
}