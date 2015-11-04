// Created 03.11.2015 
// Modified by Gorbach Alex 04.11.2015 at 13:01

namespace Assets.Scripts.Engine.Factory.Strategy {
    #region References

    using System.Collections.Generic;

    #endregion

    internal interface IChooseStrategy<T>
        where T : class {
        T Get(IEnumerable<T> items);
    }
}