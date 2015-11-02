// Created 02.11.2015
// Modified by Александр 02.11.2015 at 20:37

namespace Assets.Scripts.UI.Visualizers.Bonuses {
    #region References

    using EndlessEngine.Bonuses;
    using Engine;
    using Gameplay.Bonuses;
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
        private IBonusGenerator _generator;

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
            _generator.BeginCollect += AddBonus;
        }

        private void AddBonus(IBonus bonus) {
            Balanse += bonus.Strength;
        }

        protected override void Awake() {
            base.Awake();
            _animator = GetComponent<Animator>();
        }
    }
}