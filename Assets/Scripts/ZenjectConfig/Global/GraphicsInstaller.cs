// Created 03.11.2015
// Modified by Александр 03.11.2015 at 21:36

namespace Assets.Scripts.ZenjectConfig.Global {
    #region References

    using UI.Graphics;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class GraphicsInstaller : MonoInstaller {
        [SerializeField]
        private GraphicsCache _purchaseCache;

        public override void InstallBindings() {
            Container.Bind<GraphicsCache>(GraphicCacheKeys.PURCHASE).ToInstance(_purchaseCache);
        }
    }
}