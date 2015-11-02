// Created 28.10.2015
// Modified by Александр 02.11.2015 at 21:01

namespace Assets.Scripts.Engine.Factory.Strategy {
    #region References

    using System.Collections.Generic;
    using System.Linq;

    #endregion

    internal class FirstAvailableStrategy<T> : IPoolStrategy<T> where T : class {
        public T Get(IEnumerable<T> items) {
            return items.First();
        }
    }
}