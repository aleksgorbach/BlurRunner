// Created 26.10.2015 
// Modified by Gorbach Alex 26.10.2015 at 13:17

namespace Assets.Scripts.Engine.Factory.Strategy {
    #region References

    using System.Collections.Generic;
    using System.Linq;

    #endregion

    internal class FirstAvailableStrategy : IGettingStrategy {
        public T Get<T>(IEnumerable<T> items) {
            return items.First();
        }
    }
}