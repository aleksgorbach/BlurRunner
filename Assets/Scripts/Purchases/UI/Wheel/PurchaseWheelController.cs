// Created 02.11.2015 
// Modified by Gorbach Alex 02.11.2015 at 14:01

namespace Assets.Scripts.Purchases.UI.Wheel {
    #region References

    using Engine;
    using Engine.Scrollers;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class PurchaseWheelController : MonoBehaviourBase {
        [SerializeField]
        private PurchaseUI[] _goods;

        [SerializeField]
        private RoundScroller _scroller;

        [PostInject]
        private void Inject(IInstantiator instantiator) {
            foreach (var item in _goods) {
                _scroller.AddItem(instantiator.InstantiatePrefab(item.gameObject).GetComponent<PurchaseUI>());
            }
        }

        public void OnClick() {
            _scroller.ScrollNext();
        }
    }
}