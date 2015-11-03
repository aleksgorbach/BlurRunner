// Created 03.11.2015
// Modified by Александр 03.11.2015 at 21:31

namespace Assets.Scripts.Purchases {
    #region References

    using Localization;

    #endregion

    internal class InAppItem : IInAppItem {
        public InAppItem(string nameKey, string descriptionKey, string effectKey) {
            Id = nameKey;
            Name = new LocalizableText(nameKey);
            Description = new LocalizableText(descriptionKey);
            Effect = new LocalizableText(effectKey);
        }

        public string Id { get; private set; }
        public ILocalizable Name { get; private set; }
        public ILocalizable Description { get; private set; }
        public ILocalizable Effect { get; private set; }
    }
}