namespace Assets.Scripts.UI.Popups.Implementations {
    using Platforms;
    using UnityEngine;
    using Zenject;

    internal class SettingsPopup : Popup {
        [Inject]
        private IPlatformDefines _platformDefines;

        public void RateUs() {
            Application.OpenURL(_platformDefines.MarketUrl);
        }
    }
}