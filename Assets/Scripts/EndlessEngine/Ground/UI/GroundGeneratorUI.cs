using System.Collections.Generic;
using Assets.Scripts.EndlessEngine.Ground.Generators;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.EndlessEngine.Ground.UI {
    internal class GroundGeneratorUI : MonoBehaviour {
        [Inject] private IGroundGenerator _generator;

        private Queue<GroundBlockUI> _blocks;

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
            return _generator.GetCompatibleBlock(leftBlock);
        }

        private void Add(GroundBlockUI block) {
            var rectTransform = block.GetComponent<RectTransform>();
            rectTransform.SetParent(transform, false);
            rectTransform.anchoredPosition = new Vector2(Length, 0);
            _blocks.Enqueue(block);
        }

        private float Length {
            get {
                float length = 0;
                foreach (var block in _blocks) {
                    length += block.Length;
                }
                return length;
            }
        }
    }
}