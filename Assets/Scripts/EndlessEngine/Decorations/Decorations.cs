// Created 03.11.2015
// Modified by  30.11.2015 at 14:00

namespace Assets.Scripts.EndlessEngine.Decorations {
    #region References

    using Engine;
    using Ground;
    using Hills;
    using UnityEngine;

    #endregion

    internal class Decorations : MonoBehaviourBase {
        [SerializeField]
        private HillLayer[] _hills;

        [SerializeField]
        private DecorationLayer[] _layers;

        public void Generate(float length, Decoration[] prefabs, GroundBlock[] ground) {
            foreach (var layer in _layers) {
                layer.Generate(length, prefabs);
            }
            foreach (var layer in _hills) {
                layer.Generate(length, ground);
            }
        }
    }
}