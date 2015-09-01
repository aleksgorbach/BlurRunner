using Assets.Scripts.EndlessEngine.Ground.Generators;

namespace Assets.Scripts.EndlessEngine.Ground {
    internal enum BorderLevel {
        Bottom,
        Middle,
        Top
    }

    internal interface IGroundBlock {
        BorderLevel LeftBorderLevel { get; }
        BorderLevel RightBorderLevel { get; }
        bool CanBeAttachedTo(IGroundBlock other, BlockPosition position = BlockPosition.Left);
    }
}