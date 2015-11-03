// Created 03.11.2015 
// Modified by Gorbach Alex 03.11.2015 at 15:08

namespace Assets.Scripts.Purchases.Storage {
    #region References

    using System.Collections.Generic;

    #endregion

    internal interface IInAppStorage : IEnumerable<IInAppItem> {
    }
}