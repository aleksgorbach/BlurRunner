using Assets.Scripts.EndlessEngine.Ground.UI;

namespace Assets.Scripts.EndlessEngine.Ground.Generators {
    internal interface IDecorationGenerator {
        DecorationItemUI Get();
        void Return(DecorationItemUI item);
    }
}