// Created 03.11.2015 
// Modified by Gorbach Alex 03.11.2015 at 14:57

namespace Assets.Scripts.Localization.Locales {
    #region References

    using System.Collections.Generic;

    #endregion

    internal class RussianLocale : ILocale {
        private Dictionary<string, string> _glossary;

        public RussianLocale() {
            _glossary = new Dictionary<string, string>();
        }

        public string this[string key] {
            get {
                return _glossary[key];
            }
        }
    }
}