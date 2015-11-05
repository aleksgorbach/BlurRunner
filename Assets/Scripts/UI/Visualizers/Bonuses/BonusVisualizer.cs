// Created 02.11.2015
// Modified by Александр 05.11.2015 at 20:11

namespace Assets.Scripts.UI.Visualizers.Bonuses {
    #region References

    using Engine;
    using State.Progress.Storage;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    #endregion

    [RequireComponent(typeof (Animator))]
    internal class BonusVisualizer : MonoBehaviourBase, IBonusVisualizer {
        private Animator _animator;

        [SerializeField]
        private Image _balanse;

        private float _balanseCount = 0.5f;

        [Inject]
        private IProgressStorage _progressStorage;

        private float Balanse {
            get { return _balanseCount; }
            set {
                var old = _balanseCount;
                _balanseCount = Mathf.Clamp01(value);
                _balanse.fillAmount = _balanseCount;
                _animator.SetTrigger(old < _balanseCount ? "positive" : "negative");
            }
        }

        [PostInject]
        private void PostInject() {
            _progressStorage.CurrentLevelProgress.Changed += OnProgressChanged;
        }

        private void OnProgressChanged(int currentProgress) {
            Balanse = currentProgress;
        }

        protected override void Awake() {
            base.Awake();
            _animator = GetComponent<Animator>();
        }
    }
}