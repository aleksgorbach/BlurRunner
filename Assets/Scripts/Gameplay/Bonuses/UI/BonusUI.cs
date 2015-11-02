// Created 28.10.2015 
// Modified by Gorbach Alex 02.11.2015 at 10:05

namespace Assets.Scripts.Gameplay.Bonuses.UI {
    #region References

    using System;
    using EndlessEngine;
    using EndlessEngine.Bonuses;
    using UnityEngine;

    #endregion

    internal abstract class BonusUI : HidingItem, IBonusUI {
        private bool _isCollectedNow = false;
        public IBonus Bonus { get; private set; }
        public event Action<BonusUI> Collected;
        public event Action<BonusUI> Collect;

        protected override void Awake() {
            base.Awake();
            Bonus = GetBonus();
        }

        protected abstract IBonus GetBonus();

        public void OnTriggerEnter2D(Collider2D collision) {
            if (_isCollectedNow) {
                return;
            }
            var collector = collision.GetComponent<BonusCollector>();
            if (collector != null) {
                CollectAnimation();
                OnCollect();
                _isCollectedNow = true;
            }
        }

        private void OnCollect() {
            var handler = Collect;
            if (handler != null) {
                handler.Invoke(this);
            }
        }

        private void OnCollectEnd() {
            _isCollectedNow = false;
            var handler = Collected;
            if (handler != null) {
                handler.Invoke(this);
            }
        }

        protected virtual void CollectAnimation() {
            GetComponent<Animator>().SetTrigger("collect");
        }
    }
}