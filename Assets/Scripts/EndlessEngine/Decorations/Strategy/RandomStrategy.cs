// Created 26.10.2015 
// Modified by Gorbach Alex 26.10.2015 at 13:33

#region References

#endregion

namespace Assets.Scripts.EndlessEngine.Decorations.Strategy {
    #region References

    using UnityEngine;

    #endregion

    internal class RandomStrategy : AbstractStrategy {
        [SerializeField]
        [Range(0, 1)]
        private float _chance;

        public override bool IsGeneratingNeeded {
            get {
                return Random.Range(0f, 1f) < _chance;
            }
        }
    }
}