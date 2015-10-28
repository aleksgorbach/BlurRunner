// Created 28.10.2015 
// Modified by Gorbach Alex 28.10.2015 at 16:46

namespace Assets.Scripts.Gameplay.Bonuses.UI {
    #region References

    using System;
    using EndlessEngine.Bonuses;
    using Engine;
    using UnityEngine;

    #endregion

    [RequireComponent(typeof(Collider2D))]
    internal class BonusUI : MonoBehaviourBase, IBonusUI {
        public event Action<BonusUI> Collected;

        public void OnTriggerEnter2D(Collider2D collision) {
            var collector = collision.GetComponent<BonusCollector>();
            if (collector != null) {
                Debug.Log(collector.name);
                Invoke("OnCollected", 1);
            }
        }

        private void OnCollected() {
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