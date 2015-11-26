// Created 26.11.2015
// Modified by Александр 26.11.2015 at 21:17

namespace Assets.Scripts.EndlessEngine.Ground {
    #region References

    using System.Collections.Generic;
    using Engine;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class Ground : MonoBehaviourBase {
        private Queue<GroundBlock> _blocks;

        [Inject]
        private IGroundFactory _factory;

        protected override void Awake() {
            base.Awake();
            _blocks = new Queue<GroundBlock>();
        }

        public void Generate(float length, GroundBlock[] ground) {
            _factory.Init(ground);
            var currentLength = 0f;
            GroundBlock prevBlock = null;
            while (currentLength < length) {
                var block = _factory.Create(prevBlock);
                prevBlock = block;
                _blocks.Enqueue(block);
                block.transform.SetParent(transform);
                block.rectTransform.anchoredPosition3D = new Vector3(currentLength, 0, 0);
                currentLength += block.Length;
            }
        }
    }
}