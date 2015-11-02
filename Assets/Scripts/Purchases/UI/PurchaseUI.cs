// Created 02.11.2015 
// Modified by Gorbach Alex 02.11.2015 at 13:11

namespace Assets.Scripts.Purchases.UI {
    #region References

    using Engine;
    using Engine.Scrollers;
    using UnityEngine;

    #endregion

    internal class PurchaseUI : MonoBehaviourBase, IScrollerItem {
        public IPurchase Purchase { get; private set; }

        public RectTransform Transform {
            get {
                return rectTransform;
            }
        }
    }
}