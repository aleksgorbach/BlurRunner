// Created 03.11.2015
// Modified by Александр 03.11.2015 at 22:01

namespace Assets.Scripts.Localization.Builder {
    #region References

    using System;
    using System.Linq;
    using Locales;

    #endregion

    internal class LocaleBuilder {
        public static Locale Build(LocaleData data) {
            var entries = data.Items.ToDictionary(x => x.Key, x => x.Value);
            switch (data.Locale) {
                case Keys.Locale.Russian:
                    return new RussianLocale(entries);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}