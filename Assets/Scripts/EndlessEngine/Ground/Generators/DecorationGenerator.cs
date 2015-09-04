using Assets.Scripts.EndlessEngine.Ground.UI;
using Assets.Scripts.Engine.Pool;

namespace Assets.Scripts.EndlessEngine.Ground.Generators {
    internal class DecorationGenerator : IDecorationGenerator {
        private readonly IObjectPool<DecorationItemUI> _pool;

        public DecorationGenerator(IObjectPool<DecorationItemUI> pool) {
            _pool = pool;
        }

        public DecorationItemUI Get() {
            var obj = _pool.Get();
            obj.gameObject.SetActive(true);
            return obj;
        }

        public void Return(DecorationItemUI item) {
            _pool.Release(item);
        }
    }
}