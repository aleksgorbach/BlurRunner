namespace Assets.Scripts.UI.Popups.Settings {
    using Engine;
    using Scripts.Settings;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    internal class SettingsItem : MonoBehaviourBase {
        [SerializeField]
        private Image _enabledIndicator;

        [SerializeField]
        private Setting _setting;

        [Inject]
        private ISettingsManager _settingsManager;

        public void SwitchState(bool isEnabled) {
            _settingsManager[_setting].IsEnabled = isEnabled;
            _enabledIndicator.gameObject.SetActive(isEnabled);
        }
    }
}