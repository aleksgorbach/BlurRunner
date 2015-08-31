using System;

namespace Assets.Scripts.EndlessEngine.Ground.Generators {
    internal class GroundGenerator : IGroundGenerator {
        public IGroundBlock GetCompatibleBlock(IGroundBlock origin, BlockPosition position = BlockPosition.Left) {
            throw new NotImplementedException();
        }
    }
}