namespace Assets.Scripts.Settings {
    using System.Collections.Generic;

    internal class SettingsManager : ISettingsManager {
        private readonly IDictionary<Setting, ISetting> _currentSettings;

        public SettingsManager(IDictionary<Setting, ISetting> currentSettings) {
            _currentSettings = currentSettings;
        }

        public ISetting this[Setting setting] {
            get { return _currentSettings[setting]; }
        }
    }
}