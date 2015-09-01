using System.Collections.Generic;
using Assets.Scripts.EndlessEngine.Ground.Generators;
using Assets.Scripts.EndlessEngine.Interfaces;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.EndlessEngine.Ground.UI {
    internal class GroundGeneratorUI : MonoBehaviour {
        private Queue<GroundBlockUI> _blocks;
        [Inject] private IGroundGenerator _generator;

        private float Length {
            get {
                float length = 0;
                foreach (var block in _blocks) {
                    length += block.Length;
                }
                return length;
            }
        }

        private void Awake() {
            _blocks = new Queue<GroundBlockUI>();
        }

        [PostInject]
        private void Init() {
            GroundBlockUI prevBlock = null;
            for (var i = 0; i < 4; i++) {
                var block = GenerateBlock(prevBlock);
                Add(block);
                prevBlock = block;
            }
        }

        private GroundBlockUI GenerateBlock(GroundBlockUI leftBlock) {
            var block = _generator.GetCompatibleBlock(leftBlock);
            block.BecameInvisible += OnBlockHide;
            return block;
        }

        private void Add(GroundBlockUI block) {
            var rectTransform = block.GetComponent<RectTransform>();
            rectTransform.SetParent(transform, false);
            rectTransform.anchoredPosition = new Vector2(Length, 0);
            _blocks.Enqueue(block);
        }

        private void OnBlockHide(IHiding hiding) {
            var block = (_blocks.Dequeue());
            block.BecameInvisible -= OnBlockHide;
            Add(GenerateBlock(_blocks.Peek()));
        }
    }
}