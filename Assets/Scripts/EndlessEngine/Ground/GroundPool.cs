using Assets.Scripts.EndlessEngine.Ground.UI;
using Assets.Scripts.Engine.Factory;
using Assets.Scripts.Engine.Pool;

namespace Assets.Scripts.EndlessEngine.Ground {
    internal class GroundPool : GameObjectPool<GroundBlockUI> {
        public GroundPool(bool canGrow, IFactory<GroundBlockUI> factory) : base(canGrow, factory) {
        }
    }
}