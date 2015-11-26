// Created 26.11.2015
// Modified by Александр 26.11.2015 at 20:26

namespace Assets.Scripts.EndlessEngine.Levels {
    #region References

    using System;
    using Engine;
    using Ground;
    using State.Levels;
    using UnityEngine;

    #endregion

    internal class LevelGenerator : MonoBehaviourBase, ILevelGenerator {
        [SerializeField]
        private Ground _ground;

        public void Generate(ILevel level) {
            _ground.Generate(level.Length, level.Ground);
        }

        public event Action Generated;

        private void OnGenerated() {
            var handler = Generated;
            if (handler != null) {
                handler();
            }
        }
    }
}