// Created 20.11.2015
// Modified by  20.11.2015 at 13:16

namespace Assets.Scripts.EndlessEngine.Strategy {
    internal class DistanceRandomStrategy : RandomStrategy {
        private float _prevGenerationPos;

        private float _timer;

        protected override void Awake() {
            base.Awake();
            _prevGenerationPos = transform.position.x;
            StartTimer();
        }

        private void FixedUpdate() {
            var pos = transform.position.x;
            if (pos - _prevGenerationPos >= _timer) {
                OnNeedGenerate();
                _prevGenerationPos = pos;
                StartTimer();
            }
        }

        private void StartTimer() {
            _timer = GetRandomValueWithDistribution();
        }
    }
}