// Created 15.10.2015
// Modified by Александр 25.10.2015 at 18:15

namespace Assets.Scripts.EndlessEngine.Ground {
    internal class GroundBlock : IGroundBlock {
        public GroundBlock(BorderLevel leftBorderLevel, BorderLevel rightBorderLevel) {
            LeftBorderLevel = leftBorderLevel;
            RightBorderLevel = rightBorderLevel;
        }

        public BorderLevel LeftBorderLevel { get; private set; }
        public BorderLevel RightBorderLevel { get; private set; }

        public bool CanBeAttachedTo(IGroundBlock other) {
            return LeftBorderLevel == other.RightBorderLevel;
        }
    }
}