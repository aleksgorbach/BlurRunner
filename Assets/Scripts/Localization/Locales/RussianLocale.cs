// Created 03.11.2015
// Modified by Александр 03.11.2015 at 22:00

namespace Assets.Scripts.Localization.Locales {
    #region References

    using System.Collections.Generic;
    using Keys;

    #endregion

    internal class RussianLocale : Locale {
        public RussianLocale(IDictionary<string, string> data) : base(new Dictionary<string, string> {
            {InAppKeys.VITAMINE_NAME, "Витамины"},
            {InAppKeys.VITAMINE_DESCRIPTION, "Офигенны"},
            {InAppKeys.VITAMINE_EFFECT, "Удлиняют жизнь"},
            {InAppKeys.BOOK_NAME, "Книга"},
            {InAppKeys.BOOK_DESCRIPTION, ""},
            {InAppKeys.BOOK_EFFECT, "Увеличивает везение"}
        }) {
        }

        public override Keys.Locale LocaleType {
            get { return Keys.Locale.Russian; }
        }
    }
}