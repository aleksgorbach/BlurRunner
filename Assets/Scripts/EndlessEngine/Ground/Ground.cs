// Created 27.11.2015
// Modified by  30.11.2015 at 13:52

namespace Assets.Scripts.EndlessEngine.Ground {
    #region References

    using Engine;
    using Engine.Factory;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class Ground : AbstractGenerator<GroundBlock> {
        [Inject]
        private AbstractGameObjectFactory<GroundBlock> _factory;

        [Inject]
        private IChooseStrategy<GroundBlock> _strategy;

        protected override AbstractGameObjectFactory<GroundBlock> Factory {
            get { return _factory; }
        }

        protected override IChooseStrategy<GroundBlock> Strategy {
            get { return _strategy; }
        }

        public override void Generate(float length, GroundBlock[] ground) {
            base.Generate(length, ground);
            var currentLength = 0f;
            while (currentLength < length) {
                var block = _factory.Create();
                AddItem(block);
                block.transform.SetParent(transform);
                block.rectTransform.anchoredPosition3D = new Vector3(currentLength, 0, 0);
                currentLength += block.Length;
            }
        }
    }
}