// Created 02.11.2015 
// Modified by Gorbach Alex 03.11.2015 at 15:10

namespace Assets.Scripts.Purchases {
    #region References

    using Localization;

    #endregion

    internal abstract class InAppItem : IInAppItem {
        public InAppItem(string nameKey, string descriptionKey, string effectKey) {
            Name = new LocalizableText(nameKey);
            Description = new LocalizableText(descriptionKey);
            Effect = new LocalizableText(effectKey);
        }

        public ILocalizable Name { get; private set; }
        public ILocalizable Description { get; private set; }
        public ILocalizable Effect { get; private set; }
    }
}