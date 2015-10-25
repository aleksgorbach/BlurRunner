// Created 22.10.2015
// Modified by Александр 25.10.2015 at 17:49

namespace Assets.Scripts.EndlessEngine.Ground.UI {
    #region References

    using Engine;
    using Generators;
    using Generators.Strategy;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class DecorationGeneratorUI : MonoBehaviourBase {
        [Inject]
        private IDecorationGenerator _generator;

        [SerializeField]
        private GroundGeneratorUI _groundGenerator;

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