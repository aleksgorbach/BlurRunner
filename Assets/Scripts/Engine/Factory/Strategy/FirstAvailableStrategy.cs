// Created 26.10.2015 
// Modified by Gorbach Alex 04.11.2015 at 13:02

namespace Assets.Scripts.Engine.Factory.Strategy {
    #region References

    using System.Collections.Generic;
    using System.Linq;

    #endregion

    internal class FirstAvailableStrategy<T> : IChooseStrategy<T>
        where T : class {
        public T Get(IEnumerable<T> items) {
            return items.First();
        }
    }
}