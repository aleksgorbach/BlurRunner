// Created 20.11.2015
// Modified by  20.11.2015 at 13:18

namespace Assets.Scripts.EndlessEngine.Strategy {
    #region References

    using UnityEngine;

    #endregion

    internal abstract class RandomStrategy : AbstractStrategy {
        [SerializeField]
        private float _maxValue;

        [SerializeField]
        private float _minValue;

        [SerializeField]
        private AnimationCurve _randomDistribution;

        protected float GetRandomValueWithDistribution() {
            var random = _randomDistribution.Evaluate(Random.value);
            return _minValue + random*(_maxValue - _minValue);
        }
    }
}