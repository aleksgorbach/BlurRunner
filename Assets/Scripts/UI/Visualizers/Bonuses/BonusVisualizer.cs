// Created 15.11.2015
// Modified by Александр 26.11.2015 at 20:23

namespace Assets.Scripts.UI.Visualizers.Bonuses {
    #region References

    using Engine;
    using State.Progress;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    #endregion

    internal class BonusVisualizer : MonoBehaviourBase, IBonusVisualizer {
        [SerializeField]
        private float _maxProgress;

        [SerializeField]
        private Text _points;

        [Inject]
        private ILevelProgress _progress;

        private float Balanse {
            set { _points.text = "" + value; }
        }

        [PostInject]
        private void PostInject() {
            _progress.Changed += OnProgressChanged;
        }

        private void OnProgressChanged(int currentScore) {
            Balanse = currentScore;
        }

        protected override void OnDestroy() {
            _progress.Changed -= OnProgressChanged;
        }
    }
}