using Assets.Scripts.EndlessEngine.Ground.UI;
using Assets.Scripts.Engine.Pool;

namespace Assets.Scripts.EndlessEngine.Ground.Generators {
    internal class GroundGenerator : IGroundGenerator {
        private readonly IObjectPool<GroundBlockUI> _pool;

        public GroundGenerator(IObjectPool<GroundBlockUI> pool) {
            _pool = pool;
        }

        public GroundBlockUI GetCompatibleBlock(GroundBlockUI origin, BlockPosition position = BlockPosition.Left) {
            var obj = _pool.Get();
            obj.gameObject.SetActive(true);
            return obj;
        }

        public void ReturnBlock(GroundBlockUI block) {
            _pool.Release(block);
        }
    }
}