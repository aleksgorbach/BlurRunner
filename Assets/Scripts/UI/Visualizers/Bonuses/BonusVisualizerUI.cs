// Created 30.10.2015 
// Modified by Gorbach Alex 02.11.2015 at 10:14

namespace Assets.Scripts.UI.Visualizers.Bonuses {
    #region References

    using Engine;
    using Gameplay.Bonuses;
    using Presenter;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    #endregion

    [RequireComponent(typeof(Animator))]
    internal class BonusVisualizerUI : MonoBehaviourBase, IBonusVisualizerUI {
        private Animator _animator;

        private float _balanseCount = 0.5f;

        [SerializeField]
        private Image _balanse;

        [Inject]
        private IBonusVisualizer _presenter;

        private float Balanse {
            get {
                return _balanseCount;
            }
            set {
                var old = _balanseCount;
                _balanseCount = Mathf.Clamp01(value);
                _balanse.fillAmount = _balanseCount;
                _animator.SetTrigger(old < _balanseCount ? "positive" : "negative");
            }
        }

        public void AddBonus(IBonus bonus) {
            Balanse += bonus.Strength;
        }

        protected override void Awake() {
            base.Awake();
            _animator = GetComponent<Animator>();
        }
    }
}