// Created 02.11.2015 
// Modified by Gorbach Alex 04.11.2015 at 8:53

namespace Assets.Scripts.Purchases {
    #region References

    using Localization;

    #endregion

    internal class InAppItem : IInAppItem {
        public InAppItem(string key) {
            Key = key;
            Name = new LocalizableText(GetKey("name"));
            Description = new LocalizableText(GetKey("description"));
            Effect = new LocalizableText(GetKey("effect"));
        }

        public string Key { get; private set; }
        public ILocalizable Name { get; private set; }
        public ILocalizable Description { get; private set; }
        public ILocalizable Effect { get; private set; }

        private string GetKey(string propertyName) {
            return string.Format("{0}.{1}.{2}", "purchases", Key, propertyName);
        }
    }
}