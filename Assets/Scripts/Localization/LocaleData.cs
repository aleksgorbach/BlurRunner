// Created 03.11.2015
// Modified by Александр 03.11.2015 at 21:59

namespace Assets.Scripts.Localization {
    #region References

    using Keys;

    #endregion

    public class LocaleData {
        public Item[] Items;
        public Locale Locale;

        public class Item {
            public string Key;
            public string Value;
        }
    }
}