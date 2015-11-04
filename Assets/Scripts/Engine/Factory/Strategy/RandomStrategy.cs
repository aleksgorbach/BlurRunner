// Created 26.10.2015 
// Modified by Gorbach Alex 04.11.2015 at 13:32

namespace Assets.Scripts.Engine.Factory.Strategy {
    #region References

    using System.Collections.Generic;
    using Extensions;

    #endregion

    internal class RandomStrategy<T> : IChooseStrategy<T>
        where T : class {
        public virtual T Get(IEnumerable<T> items) {
            return Filter(items).Random();
        }

        protected virtual IEnumerable<T> Filter(IEnumerable<T> items) {
            return items;
        }
    }
}