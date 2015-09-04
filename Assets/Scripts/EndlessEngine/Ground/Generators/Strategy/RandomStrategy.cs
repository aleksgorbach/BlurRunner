using UnityEngine;

namespace Assets.Scripts.EndlessEngine.Ground.Generators.Strategy {
    internal class RandomStrategy : MonoBehaviour, IGeneratingStrategy {
        [SerializeField] private float _minInterval;
        [SerializeField] private float _maxInterval;
        private GeneratingDelegate _method;

        public void Init(GeneratingDelegate generatingMethod) {
            _method = generatingMethod;
            StartWaiting();
        }

        private float _timer;

        private void Update() {
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