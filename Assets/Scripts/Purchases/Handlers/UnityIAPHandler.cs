﻿namespace Assets.Scripts.Purchases.Handlers {
    #region References

    using System;
    using UnityEngine;
    using UnityEngine.Purchasing;
    using Zenject;

    #endregion

    class UnityIAPHandler : IStoreListener, IInAppHandler, IInitializable {
        private IStoreController _storeController; // Reference to the Purchasing system.

        private IExtensionProvider _storeExtensionProvider;
        // Reference to store-specific Purchasing subsystems.

        // Product identifiers for all products capable of being purchased: "convenience" general identifiers for use with Purchasing, and their store-specific identifier counterparts 
        // for use with and outside of Unity Purchasing. Define store-specific identifiers also on each platform's publisher dashboard (iTunes Connect, Google Play Developer Console, etc.)

        private const string kProductIDConsumable = "consumable"; // General handle for the consumable product.

        private const string kProductIDNonConsumable = "nonconsumable";
        // General handle for the non-consumable product.

        private const string kProductIDSubscription = "subscription"; // General handle for the subscription product.

        private const string kProductNameAppleConsumable = "com.unity3d.test.services.purchasing.consumable";
        // Apple App Store identifier for the consumable product.

        private const string kProductNameAppleNonConsumable = "com.unity3d.test.services.purchasing.nonconsumable";
        // Apple App Store identifier for the non-consumable product.

        private const string kProductNameAppleSubscription = "com.unity3d.test.services.purchasing.subscription";
        // Apple App Store identifier for the subscription product.

        private const string kProductNameGooglePlayConsumable = "com.unity3d.test.services.purchasing.consumable";
        // Google Play Store identifier for the consumable product.

        private const string kProductNameGooglePlayNonConsumable = "com.unity3d.test.services.purchasing.nonconsumable";
        // Google Play Store identifier for the non-consumable product.

        private const string kProductNameGooglePlaySubscription = "com.unity3d.test.services.purchasing.subscription";
        // Google Play Store identifier for the subscription product.

        //void Start() {
        //    // If we haven't set up the Unity Purchasing reference
        //    if (m_StoreController == null) {
        //        // Begin to configure our connection to Purchasing
        //        InitializePurchasing();
        //    }
        //}

        public void Initialize() {
            // If we have already connected to Purchasing ...
            if (IsInitialized()) {
                // ... we are done here.
                return;
            }

            // Create a builder, first passing in a suite of Unity provided stores.
            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

            // Add a product to sell / restore by way of its identifier, associating the general identifier with its store-specific identifiers.
            builder.AddProduct(kProductIDConsumable, ProductType.Consumable,
                new IDs {
                    {kProductNameAppleConsumable, AppleAppStore.Name},
                    {kProductNameGooglePlayConsumable, GooglePlay.Name}
                });
            // Continue adding the non-consumable product.
            builder.AddProduct(kProductIDNonConsumable, ProductType.NonConsumable,
                new IDs {
                    {kProductNameAppleNonConsumable, AppleAppStore.Name},
                    {kProductNameGooglePlayNonConsumable, GooglePlay.Name}
                });
            // And finish adding the subscription product.
            builder.AddProduct(kProductIDSubscription, ProductType.Subscription,
                new IDs {
                    {kProductNameAppleSubscription, AppleAppStore.Name},
                    {kProductNameGooglePlaySubscription, GooglePlay.Name}
                });
            // Kick off the remainder of the set-up with an asynchrounous call, passing the configuration and this class' instance. Expect a response either in OnInitialized or OnInitializeFailed.
            UnityPurchasing.Initialize(this, builder);
        }


        private bool IsInitialized() {
            // Only say we are initialized if both the Purchasing references are set.
            return _storeController != null && _storeExtensionProvider != null;
        }


        public void BuyConsumable() {
            // Buy the consumable product using its general identifier. Expect a response either through ProcessPurchase or OnPurchaseFailed asynchronously.
            BuyProductID(kProductIDConsumable);
        }


        public void BuyNonConsumable() {
            // Buy the non-consumable product using its general identifier. Expect a response either through ProcessPurchase or OnPurchaseFailed asynchronously.
            BuyProductID(kProductIDNonConsumable);
        }


        public void BuySubscription() {
            // Buy the subscription product using its the general identifier. Expect a response either through ProcessPurchase or OnPurchaseFailed asynchronously.
            BuyProductID(kProductIDSubscription);
        }


        void BuyProductID(string productId) {
            // If the stores throw an unexpected exception, use try..catch to protect my logic here.
            try {
                // If Purchasing has been initialized ...
                if (IsInitialized()) {
                    // ... look up the Product reference with the general product identifier and the Purchasing system's products collection.
                    var product = _storeController.products.WithID(productId);

                    // If the look up found a product for this device's store and that product is ready to be sold ... 
                    if (product != null && product.availableToPurchase) {
                        Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                        // ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed asynchronously.
                        _storeController.InitiatePurchase(product);
                    }
                    // Otherwise ...
                    else {
                        // ... report the product look-up failure situation  
                        Debug.Log(
                            "BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
                    }
                }
                // Otherwise ...
                else {
                    // ... report the fact Purchasing has not succeeded initializing yet. Consider waiting longer or retrying initiailization.
                    Debug.Log("BuyProductID FAIL. Not initialized.");
                }
            }
                // Complete the unexpected exception handling ...
            catch (Exception e) {
                // ... by reporting any unexpected exception for later diagnosis.
                Debug.Log("BuyProductID: FAIL. Exception during purchase. " + e);
            }
        }


        // Restore purchases previously made by this customer. Some platforms automatically restore purchases. Apple currently requires explicit purchase restoration for IAP.
        public void RestorePurchases() {
            // If Purchasing has not yet been set up ...
            if (!IsInitialized()) {
                // ... report the situation and stop restoring. Consider either waiting longer, or retrying initialization.
                Debug.Log("RestorePurchases FAIL. Not initialized.");
                return;
            }

            // If we are running on an Apple device ... 
            if (Application.platform == RuntimePlatform.IPhonePlayer ||
                Application.platform == RuntimePlatform.OSXPlayer) {
                // ... begin restoring purchases
                Debug.Log("RestorePurchases started ...");

                // Fetch the Apple store-specific subsystem.
                var apple = _storeExtensionProvider.GetExtension<IAppleExtensions>();
                // Begin the asynchronous process of restoring purchases. Expect a confirmation response in the Action<bool> below, and ProcessPurchase if there are previously purchased products to restore.
                apple.RestoreTransactions(result => {
                    // The first phase of restoration. If no more responses are received on ProcessPurchase then no purchases are available to be restored.
                    Debug.Log("RestorePurchases continuing: " + result +
                              ". If no further messages, no purchases available to restore.");
                });
            }
            // Otherwise ...
            else {
                // We are not running on an Apple device. No work is necessary to restore purchases.
                Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
            }
        }


        //  
        // --- IStoreListener
        //

        public void OnInitialized(IStoreController controller, IExtensionProvider extensions) {
            // Purchasing has succeeded initializing. Collect our Purchasing references.
            Debug.Log("OnInitialized: PASS");

            // Overall Purchasing system, configured with products for this application.
            _storeController = controller;
            // Store specific subsystem, for accessing device-specific store features.
            _storeExtensionProvider = extensions;
        }


        public void OnInitializeFailed(InitializationFailureReason error) {
            // Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
            Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
        }


        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args) {
            // A consumable product has been purchased by this user.
            if (String.Equals(args.purchasedProduct.definition.id, kProductIDConsumable, StringComparison.Ordinal)) {
                Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
                //If the consumable item has been successfully purchased, add 100 coins to the player's in-game score.
                //ScoreManager.score += 100;
            }

            // Or ... a non-consumable product has been purchased by this user.
            else if (String.Equals(args.purchasedProduct.definition.id, kProductIDNonConsumable, StringComparison.Ordinal)) {
                Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            } // Or ... a subscription product has been purchased by this user.
            else if (String.Equals(args.purchasedProduct.definition.id, kProductIDSubscription,
                StringComparison.Ordinal)) {
                Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'",
                    args.purchasedProduct.definition.id));
            } // Or ... an unknown product has been purchased by this user. Fill in additional products here.
            else {
                Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'",
                    args.purchasedProduct.definition.id));
            }
            // Return a flag indicating wither this product has completely been received, or if the application needs to be reminded of this purchase at next app launch. Is useful when saving purchased products to the cloud, and when that save is delayed.
            return PurchaseProcessingResult.Complete;
        }


        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason) {
            // A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing this reason with the user.
            Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}",
                product.definition.storeSpecificId, failureReason));
        }

        public void Purchase(IInAppItem item) {
            //throw new NotImplementedException();
            BuyProductID(item.Key);
        }
    }
}