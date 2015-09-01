using Assets.Scripts.EndlessEngine.Ground.UI;
using Assets.Scripts.Engine.Factory;

namespace Assets.Scripts.EndlessEngine.Ground.Generators {
    internal class GroundGenerator : IGroundGenerator {
        private readonly IFactory<GroundBlockUI> _factory;

        public GroundGenerator(IFactory<GroundBlockUI> factory) {
            _factory = factory;
        }

        public GroundBlockUI GetCompatibleBlock(GroundBlockUI origin, BlockPosition position = BlockPosition.Left) {
            return _factory.Create();
        }
    }
}