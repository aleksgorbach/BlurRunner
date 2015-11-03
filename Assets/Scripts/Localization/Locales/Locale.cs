// Created 03.11.2015
// Modified by Александр 03.11.2015 at 21:55

namespace Assets.Scripts.Localization.Locales {
    #region References

    using System.Collections.Generic;

    #endregion

    internal abstract class Locale {
        private readonly IDictionary<string, string> _glossary;

        protected Locale(IDictionary<string, string> glossary) {
            _glossary = glossary;
        }

        public string this[string key] {
            get { return _glossary[key]; }
        }

        public abstract Keys.Locale LocaleType { get; }
    }
}