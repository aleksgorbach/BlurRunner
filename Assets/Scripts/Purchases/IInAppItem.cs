// Created 02.11.2015 
// Modified by Gorbach Alex 03.11.2015 at 14:37

namespace Assets.Scripts.Purchases {
    #region References

    using Localization;

    #endregion

    internal interface IInAppItem {
        string Id { get; }
        ILocalizable Name { get; }
        ILocalizable Description { get; }
        ILocalizable Effect { get; }
    }
}