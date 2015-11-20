// Created 06.11.2015
// Modified by  20.11.2015 at 13:17

namespace Assets.Scripts.EndlessEngine.Strategy {
    #region References

    using System;
    using Engine.Utils;

    #endregion

    internal class TimeRandomStrategy : RandomStrategy {
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
            var random = GetRandomValueWithDistribution();
            var time = TimeSpan.FromSeconds(random);
            _timer.StartTimer(time);
        }
    }
}