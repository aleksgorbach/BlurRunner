using Assets.Scripts.EndlessEngine.Ground.Generators;
using Assets.Scripts.EndlessEngine.Ground.Generators.Strategy;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.EndlessEngine.Ground.UI {
    internal class DecorationGeneratorUI : MonoBehaviour {
        [SerializeField] private GroundGeneratorUI _groundGenerator;

        [Inject] private IDecorationGenerator _generator;
        [Inject] private IGeneratingStrategy _strategy;

        [PostInject]
        private void Init() {
            _strategy.Init(Generate);
        }

        private void Generate() {
            Debug.Log("generate");
        }
    }
}