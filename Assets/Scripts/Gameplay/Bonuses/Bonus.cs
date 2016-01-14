// Created 28.10.2015
// Modified by  14.01.2016 at 9:52

namespace Assets.Scripts.Gameplay.Bonuses {
    #region References

    using System;
    using EndlessEngine.Bonuses;
    using Engine;
    using Engine.Factory.ChooseStrategies;
    using UnityEngine;

    #endregion

    internal abstract class Bonus : MonoBehaviourBase, IBonus, IWeightable {
        private bool _isCollectedNow;

        protected abstract int Direction { get; }
        protected abstract int Force { get; }

        public event Action<Bonus> Collected;
        public event Action<Bonus> EndCollected;

        public int Points {
            get { return Force*Direction; }
        }

        public abstract void Apply();

        public virtual float Weight {
            get { return 1; }
        }

        public void OnTriggerEnter2D(Collider2D collision) {
            if (_isCollectedNow) {
                return;
            }
            var collector = collision.GetComponent<BonusCollector>();
            if (collector != null) {
                CollectAnimation();
                OnCollected();
                _isCollectedNow = true;
            }
        }

        private void OnCollected() {
            var handler = Collected;
            if (handler != null) {
                handler.Invoke(this);
            }
        }

        private void OnCollectEnd() {
            _isCollectedNow = false;
            var handler = EndCollected;
            if (handler != null) {
                handler.Invoke(this);
            }
            Destroy(gameObject);
        }

        protected virtual void CollectAnimation() {
            GetComponent<Animator>().SetTrigger("collect");
        }
    }
}