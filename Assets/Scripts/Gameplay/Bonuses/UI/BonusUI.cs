// Created 28.10.2015
// Modified by Александр 29.10.2015 at 21:57

namespace Assets.Scripts.Gameplay.Bonuses.UI {
    #region References

    using System;
    using EndlessEngine.Bonuses;
    using Engine;
    using UnityEngine;

    #endregion

    [RequireComponent(typeof (Collider2D))]
    internal class BonusUI : MonoBehaviourBase, IBonusUI {
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