// Created 02.11.2015
// Modified by Александр 02.11.2015 at 20:27

namespace Assets.Scripts.Gameplay.Bonuses {
    #region References

    using System;
    using EndlessEngine;
    using EndlessEngine.Bonuses;
    using UnityEngine;

    #endregion

    internal abstract class Bonus : HidingItem, IBonus {
        private bool _isCollectedNow = false;

        protected abstract int Direction { get; }
        protected abstract float Force { get; }
        public event Action<Bonus> BeginCollect;
        public event Action<Bonus> EndCollect;

        public float Strength {
            get { return Force*Direction; }
        }

        public abstract void Apply();

        public void OnTriggerEnter2D(Collider2D collision) {
            if (_isCollectedNow) {
                return;
            }
            var collector = collision.GetComponent<BonusCollector>();
            if (collector != null) {
                CollectAnimation();
                OnCollectEnter();
                _isCollectedNow = true;
            }
        }

        private void OnCollectEnter() {
            var handler = BeginCollect;
            if (handler != null) {
                handler.Invoke(this);
            }
        }

        private void OnCollectEnd() {
            _isCollectedNow = false;
            var handler = EndCollect;
            if (handler != null) {
                handler.Invoke(this);
            }
        }

        protected virtual void CollectAnimation() {
            GetComponent<Animator>().SetTrigger("collect");
        }
    }
}