namespace Assets.Scripts.EndlessEngine.Ground.Generators {
    internal enum BlockPosition {
        Left,
        Right
    }

    internal interface IGroundGenerator {
        IGroundBlock GetCompatibleBlock(IGroundBlock origin, BlockPosition position = BlockPosition.Left);
    }
}