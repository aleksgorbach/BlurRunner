using Assets.Scripts.EndlessEngine.Ground.Generators;

namespace Assets.Scripts.EndlessEngine.Ground {
    internal class GroundBlock : IGroundBlock {
        public BorderLevel LeftBorderLevel { get; private set; }
        public BorderLevel RightBorderLevel { get; private set; }

        public GroundBlock(BorderLevel leftBorderLevel, BorderLevel rightBorderLevel) {
            LeftBorderLevel = leftBorderLevel;
            RightBorderLevel = rightBorderLevel;
        }

        public bool CanBeAttachedTo(IGroundBlock other, BlockPosition position = BlockPosition.Left) {
            switch (position) {
                case BlockPosition.Left:
                    return RightBorderLevel == other.LeftBorderLevel;
                case BlockPosition.Right:
                    return LeftBorderLevel == other.RightBorderLevel;
                default:
                    return false;
            }
        }
    }
}