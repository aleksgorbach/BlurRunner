// Created 03.11.2015 
// Modified by Gorbach Alex 03.11.2015 at 15:03

namespace Assets.Scripts.Purchases.Wheel {
    #region References

    using Handlers;
    using UI.Visualizers.InApps;
    using Engine.Input;
    using Engine;
    using Engine.Scrollers;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    #endregion

    internal class PurchaseWheelController : MonoBehaviourBase {
        public const string PURCHASE_BUTTON = "purchase_button";

        [SerializeField]
        private VisualPurchase[] _goods;

        [SerializeField]
        private ItemDescription _description;

        [Inject]
        private IRoundScroller _scroller;

        [Inject]
        private IInstantiator _instantiator;

        [Inject]
        private IInputController _inputController;

        [Inject]
        private IInAppHandler _purchaseHandler;

        [Inject(PURCHASE_BUTTON)]
        private Button _purchaseButton;

        [PostInject]
        private void Inject() {
            //todo создавать через фабрику
            foreach (var item in _goods) {
                _scroller.AddItem(_instantiator.InstantiatePrefab(item.gameObject).GetComponent<VisualPurchase>());
            }
            _inputController.DragRight += _scroller.ScrollPrevious;
            _inputController.DragLeft += _scroller.ScrollNext;
            _scroller.CurrentChanged += OnCurrentChanged;
            _purchaseButton.onClick.AddListener(OnPurchaseButtonClick);
        }

        private void OnPurchaseButtonClick() {
            var current = _scroller.Current as VisualPurchase;
            _purchaseHandler.Purchase(current.Item);
        }

        private void OnCurrentChanged(IScrollerItem current) {
            _description.Item = (current as VisualPurchase).Item;
        }
    }
}