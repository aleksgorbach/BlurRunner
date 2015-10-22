// Created 20.10.2015 
// Modified by Gorbach Alex 22.10.2015 at 15:27

namespace Assets.Scripts.EndlessEngine.Ground.UI {
    #region References

    using Generators;
    using Generators.Strategy;
    using Engine;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class DecorationGeneratorUI : MonoBehaviourBase {
        [SerializeField]
        private GroundGeneratorUI _groundGenerator;

        [Inject]
        private IDecorationGenerator _generator;

        [SerializeField]
        private GeneratingStrategy _strategy;

        [PostInject]
        private void Init() {
            _strategy.Init(Generate);
        }

        private void Generate() {
            Debug.Log("generate");
        }
    }
}