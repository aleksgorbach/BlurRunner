// Created 28.11.2015
// Modified by Александр 28.11.2015 at 22:05

namespace Assets.Scripts.EndlessEngine.Decorations {
    #region References

    using Engine;
    using Strategy;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class DecorationLayer : AbstractGenerator<Decoration>, IDecorationGenerator {
        [Inject]
        private DecorationsFactory _factory;

        [SerializeField]
        private AbstractStrategy _strategy;

        public override void Generate(float length, Decoration[] prefabs) {
            _factory.Init(prefabs);
            var currentPos = _strategy.DistanceToGenerate;
            while (currentPos < length) {
                var decoration = _factory.Create();
                AddItem(decoration);
                decoration.transform.SetParent(transform);
                decoration.rectTransform.anchoredPosition3D = new Vector3(currentPos, 0, 0);
                currentPos += _strategy.DistanceToGenerate;
            }
        }
    }
}