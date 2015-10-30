// Created 28.10.2015 
// Modified by Gorbach Alex 30.10.2015 at 14:54

namespace Assets.Scripts.Gameplay.Bonuses.UI {
    #region References

    using System;
    using EndlessEngine;
    using EndlessEngine.Bonuses;
    using UnityEngine;

    #endregion

    internal class BonusUI : HidingItem, IBonusUI {
        private bool _isCollectedNow = false;
        public IBonus Bonus { get; private set; }
        public event Action<BonusUI> Collected;

        public void OnTriggerEnter2D(Collider2D collision) {
            if (_isCollectedNow) {
                return;
            }
            var collector = collision.GetComponent<BonusCollector>();
            if (collector != null) {
                Collect();
                _isCollectedNow = true;
            }
        }

        private void OnCollected() {
            _isCollectedNow = false;
            var handler = Collected;
            if (handler != null) {
                handler.Invoke(this);
            }
        }

        protected virtual void Collect() {
            GetComponent<Animator>().SetTrigger("collect");
        }
    }
}