// Created 20.10.2015 
// Modified by Gorbach Alex 22.10.2015 at 15:50

#region References

using UnityEngine;

#endregion

namespace Assets.Scripts.EndlessEngine.Ground.Generators.Strategy {
    internal class RandomStrategy : GeneratingStrategy {
        [SerializeField]
        private float _minInterval;

        [SerializeField]
        private float _maxInterval;

        private GeneratingDelegate _method;

        private float _timer;

        public override void Init(GeneratingDelegate generatingMethod) {
            _method = generatingMethod;
            StartWaiting();
        }

        protected override void Update() {
            base.Update();
            _timer -= Time.deltaTime;
            if (_timer <= 0) {
                _method.Invoke();
                StartWaiting();
            }
        }

        private void StartWaiting() {
            _timer = Random.Range(_minInterval, _maxInterval);
        }
    }
}