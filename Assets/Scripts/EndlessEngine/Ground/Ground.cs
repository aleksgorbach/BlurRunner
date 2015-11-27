// Created 27.11.2015
// Modified by  27.11.2015 at 10:22

namespace Assets.Scripts.EndlessEngine.Ground {
    #region References

    using Engine;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class Ground : AbstractGenerator<GroundBlock> {
        [Inject]
        private GroundFactory _factory;

        public override void Generate(float length, GroundBlock[] ground) {
            _factory.Init(ground);
            var currentLength = 0f;
            GroundBlock prevBlock = null;
            while (currentLength < length) {
                var block = _factory.Create(prevBlock);
                prevBlock = block;
                AddItem(block);
                block.transform.SetParent(transform);
                block.rectTransform.anchoredPosition3D = new Vector3(currentLength, 0, 0);
                currentLength += block.Length;
            }
        }
    }
}