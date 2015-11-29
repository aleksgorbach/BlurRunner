// Created 28.11.2015
// Modified by Александр 28.11.2015 at 22:07

namespace Assets.Scripts.EndlessEngine.Decorations {
    #region References

    using Engine;
    using UnityEngine;

    #endregion

    internal class Decorations : AbstractGenerator<Decoration>, IDecorationGenerator {
        [SerializeField]
        private DecorationLayer[] _layers;

        public override void Generate(float length, Decoration[] prefabs) {
            foreach (var layer in _layers) {
                layer.Generate(length, prefabs);
            }
        }
    }
}