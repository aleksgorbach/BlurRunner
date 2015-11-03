// Created 02.11.2015 
// Modified by Gorbach Alex 03.11.2015 at 15:18

namespace Assets.Scripts.ZenjectConfig {
    #region References

    using Assets.Scripts.Purchases;
    using Assets.Scripts.UI.Visualizers.InApps;
    using Purchases.Handlers;
    using Purchases.Wheel;
    using Engine.Scrollers;
    using Engine.Input;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    #endregion

    internal class ShopInstaller : MonoInstaller {
        [SerializeField]
        private VisualPurchase _purchasePrefab;

        [SerializeField]
        private InputController _inputController;

        [SerializeField]
        private RoundScroller _scroller;

        [SerializeField]
        private Button _purchaseButton;

        public override void InstallBindings() {
            Container.Bind<IInputController>().ToInstance(_inputController);
            Container.Bind<IRoundScroller>().ToInstance(_scroller);
            Container.Bind<Button>(PurchaseWheelController.PURCHASE_BUTTON)
                .ToInstance(_purchaseButton)
                .WhenInjectedInto<PurchaseWheelController>();
            Container.Bind<IInAppHandler>().ToSingle<EditorInAppHandler>();
            Container.BindGameObjectFactory<VisualPurchaseFactory>(_purchasePrefab.gameObject);
        }
    }
}