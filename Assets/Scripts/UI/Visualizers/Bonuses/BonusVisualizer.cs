// Created 09.11.2015 
// Modified by Gorbach Alex 09.11.2015 at 17:37

namespace Assets.Scripts.UI.Visualizers.Bonuses {
    #region References

    using State.Progress;
    using Engine;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    #endregion

    [RequireComponent(typeof(Animator))]
    internal class BonusVisualizer : MonoBehaviourBase, IBonusVisualizer {
        private Animator _animator;

        [SerializeField]
        private Image _balanse;

        [SerializeField]
        private float _maxProgress;

        private float _balanseCount = 0.5f;

        [Inject]
        private ILevelProgress _progress;

        private float Balanse {
            get {
                return _balanseCount;
            }
            set {
                var old = _balanseCount;
                _balanseCount = Mathf.Clamp01(value / _maxProgress);
                _balanse.fillAmount = _balanseCount;
                _animator.SetTrigger(old < _balanseCount ? "positive" : "negative");
            }
        }

        [PostInject]
        private void PostInject() {
            _progress.Changed += OnProgressChanged;
        }

        private void OnProgressChanged(int deltaScore) {
            Debug.Log("Current progress: " + deltaScore);
            Balanse += deltaScore;
        }

        protected override void Awake() {
            base.Awake();
            _animator = GetComponent<Animator>();
        }
    }
}