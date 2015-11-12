// Created 03.11.2015 
// Modified by Gorbach Alex 12.11.2015 at 12:24

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

        [SerializeField]
        private Text _points;

        private float _balanseCount = 0;

        [Inject]
        private ILevelProgress _progress;

        private float Balanse {
            set {
                var old = _balanseCount;
                _balanseCount = Mathf.Clamp01(value / _maxProgress);
                _balanse.fillAmount = _balanseCount + .5f;
                _points.text = "" + value;
                _animator.SetTrigger(old < _balanseCount ? "positive" : "negative");
            }
        }

        [PostInject]
        private void PostInject() {
            _progress.Changed += OnProgressChanged;
        }

        private void OnProgressChanged(int currentScore) {
            Balanse = currentScore;
        }

        protected override void Awake() {
            base.Awake();
            _animator = GetComponent<Animator>();
        }

        protected override void OnDestroy() {
            _progress.Changed -= OnProgressChanged;
        }
    }
}