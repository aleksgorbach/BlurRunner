// Created 26.10.2015 
// Modified by Gorbach Alex 26.10.2015 at 13:14

namespace Assets.Scripts.Engine.Factory.Strategy {
    #region References

    using System.Collections.Generic;

    #endregion

    internal interface IGettingStrategy {
        T Get<T>(IEnumerable<T> items);
    }
}