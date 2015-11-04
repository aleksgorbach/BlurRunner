// Created 02.11.2015 
// Modified by Gorbach Alex 04.11.2015 at 8:52

namespace Assets.Scripts.Purchases {
    #region References

    using Localization;

    #endregion

    internal interface IInAppItem {
        string Key { get; }
        ILocalizable Name { get; }
        ILocalizable Description { get; }
        ILocalizable Effect { get; }
    }
}