// Created 03.11.2015
// Modified by Александр 03.11.2015 at 21:51

namespace Assets.Scripts.Purchases.Wheel {
    #region References

    using Engine;
    using Engine.Input;
    using Engine.Scrollers;
    using Handlers;
    using Storage;
    using UI.Visualizers.InApps;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    #endregion

    internal class PurchaseWheelController : MonoBehaviourBase {
        public const string PURCHASE_BUTTON = "purchase_button";

        [SerializeField]
        private ItemDescription _description;

        [Inject]
        private VisualPurchase.Factory _factory;

        [Inject]
        private IInputController _inputController;

        [Inject(PURCHASE_BUTTON)]
        private Button _purchaseButton;

        [Inject]
        private IInAppHandler _purchaseHandler;

        [Inject]
        private IRoundScroller _scroller;

        [Inject]
        private IInAppStorage _storage;

        [PostInject]
        private void Inject() {
            _scroller.CurrentChanged += OnCurrentChanged;
            foreach (var item in _storage) {
                var visualItem = _factory.Create();
                visualItem.Init(item);
                _scroller.AddItem(visualItem);
            }
            _inputController.DragRight += _scroller.ScrollPrevious;
            _inputController.DragLeft += _scroller.ScrollNext;

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