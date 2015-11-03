// Created 03.11.2015
// Modified by Александр 03.11.2015 at 19:11

namespace Assets.Scripts.ZenjectConfig {
    #region References

    using Engine.Input;
    using Engine.Scrollers;
    using Purchases.Handlers;
    using Purchases.Wheel;
    using UI.Visualizers.InApps;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    #endregion

    internal class ShopInstaller : MonoInstaller {
        [SerializeField]
        private InputController _inputController;

        [SerializeField]
        private Button _purchaseButton;

        [SerializeField]
        private VisualPurchase _purchasePrefab;

        [SerializeField]
        private RoundScroller _scroller;

        public override void InstallBindings() {
            Container.Bind<IInputController>().ToInstance(_inputController);
            Container.Bind<IRoundScroller>().ToInstance(_scroller);
            Container.Bind<Button>(PurchaseWheelController.PURCHASE_BUTTON)
                .ToInstance(_purchaseButton)
                .WhenInjectedInto<PurchaseWheelController>();
            
            Container.BindGameObjectFactory<VisualPurchase.Factory>(_purchasePrefab.gameObject);
        }
    }
}