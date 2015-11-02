// Created 26.10.2015 
// Modified by Gorbach Alex 28.10.2015 at 13:04

namespace Assets.Scripts.Engine.Factory.Strategy {
    #region References

    using System.Collections.Generic;
    using Extensions;

    #endregion

    internal class RandomStrategy<T> : IPoolStrategy<T> where T : class {
        public T Get(IEnumerable<T> items) {
            return items.Random();
        }
    }
}