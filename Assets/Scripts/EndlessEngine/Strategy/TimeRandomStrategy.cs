// Created 06.11.2015 
// Modified by Gorbach Alex 06.11.2015 at 14:31

namespace Assets.Scripts.EndlessEngine.Strategy {
    #region References

    using System;
    using Engine.Utils;
    using UnityEngine;
    using Random = UnityEngine.Random;

    #endregion

    internal class TimeRandomStrategy : AbstractStrategy {
        [SerializeField]
        private float _minTime;

        [SerializeField]
        private float _maxTime;

        [SerializeField]
        private AnimationCurve _timeRandom;

        private Timer _timer;

        protected override void Awake() {
            base.Awake();
            _timer = gameObject.AddComponent<Timer>();
            _timer.Tick += OnTimer;
            StartTimer();
        }

        private void OnTimer() {
            OnNeedGenerate();
            StartTimer();
        }

        private void StartTimer() {
            var x = Random.value;
            var y = _timeRandom.Evaluate(x);
            var time = TimeSpan.FromSeconds(_minTime + y * (_maxTime - _minTime));
            _timer.StartTimer(time);
        }
    }
}