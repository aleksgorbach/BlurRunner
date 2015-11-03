// Created 03.11.2015 
// Modified by Gorbach Alex 03.11.2015 at 14:40

namespace Assets.Scripts.UI.Visualizers.InApps {
    #region References

    using Assets.Scripts.Engine.Scrollers;
    using Engine;
    using Purchases;
    using UnityEngine;

    #endregion

    internal class VisualPurchase : MonoBehaviourBase, IScrollerItem {
        public IInAppItem Item { get; private set; }

        public RectTransform Transform {
            get {
                return rectTransform;
            }
        }
    }
}