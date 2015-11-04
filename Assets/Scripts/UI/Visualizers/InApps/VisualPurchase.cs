// Created 03.11.2015 
// Modified by Gorbach Alex 04.11.2015 at 8:53

namespace Assets.Scripts.UI.Visualizers.InApps {
    #region References

    using Engine;
    using Engine.Scrollers;
    using Graphics;
    using Purchases;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    #endregion

    internal class VisualPurchase : MonoBehaviourBase, IScrollerItem {
        [Inject(GraphicCacheKeys.PURCHASE)]
        private GraphicsCache _graphics;

        [SerializeField]
        private Image _image;

        public IInAppItem Item { get; private set; }

        public RectTransform Transform {
            get {
                return rectTransform;
            }
        }

        public void Init(IInAppItem item) {
            Item = item;
            _image.sprite = _graphics[item.Key];
        }

        public class Factory : GameObjectFactory<VisualPurchase> {
        }
    }
}