namespace Assets.Scripts.Ads {
    #region References

    using AppodealAds.Unity.Api;
    using Services;
    using Zenject;

    #endregion

    internal class AdManager : IAdManager {
        [Inject]
        private IServicesConfig _servicesConfig;

        [PostInject]
        private void Initialize() {
            if (_servicesConfig.IsAdsEnabled) {
                Appodeal.initialize(_servicesConfig.AppodealApiKey, Appodeal.ALL);
                Appodeal.setTesting(_servicesConfig.IsTesting);
            }
        }

        public void ShowBanner() {
            if (_servicesConfig.IsAdsEnabled) {
                Appodeal.show(Appodeal.BANNER_TOP);
            }
        }

        public void ShowFullscreen() {
            if (_servicesConfig.IsAdsEnabled) {
                Appodeal.show(Appodeal.INTERSTITIAL);
            }
        }
    }
}