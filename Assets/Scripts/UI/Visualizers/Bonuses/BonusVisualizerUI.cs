// Created 29.10.2015
// Modified by Александр 29.10.2015 at 21:49

namespace Assets.Scripts.UI.Visualizers.Bonuses {
    #region References

    using Engine;
    using Gameplay.Bonuses;
    using Presenter;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    #endregion

    [RequireComponent(typeof (Animator))]
    internal class BonusVisualizerUI : MonoBehaviourBase, IBonusVisualizerUI {
        private Animator _animator;

        private int _collectedCount = 0;

        [SerializeField]
        private Text _count;

        [Inject]
        private IBonusVisualizer _presenter;

        private int Count {
            set {
                _count.text = value + "";
                _animator.SetTrigger("added");
            }
        }

        public void AddBonus(IBonus bonus) {
            Count = ++_collectedCount;
        }

        protected override void Awake() {
            base.Awake();
            _animator = GetComponent<Animator>();
        }
    }
}