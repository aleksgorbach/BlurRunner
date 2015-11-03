// Created 03.11.2015 
// Modified by Gorbach Alex 03.11.2015 at 14:59

namespace Assets.Scripts.Localization.Localizators {
    #region References

    using Locales;
    using Zenject;

    #endregion

    internal class DefaultLocalizator : ILocalizator {
        public const string DEFAULT_LOCALE_KEY = "default_locale";
        private readonly Locale _locale;

        public DefaultLocalizator([Inject(DEFAULT_LOCALE_KEY)] Locale defaultLocale) {
            _locale = defaultLocale;
        }

        public string Localize(ILocalizable text) {
            return _locale[text.Key];
        }
    }
}