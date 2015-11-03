// Created 03.11.2015 
// Modified by Gorbach Alex 03.11.2015 at 14:34

namespace Assets.Scripts.Localization {
    internal class LocalizableText : ILocalizable {
        public LocalizableText(string key) {
            Key = key;
        }

        public string Key { get; private set; }
    }
}