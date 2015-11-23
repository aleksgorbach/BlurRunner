// Created 26.10.2015
// Modified by  23.11.2015 at 9:32

namespace Assets.Scripts.Engine.Factory.Strategy {
    #region References

    using System.Collections.Generic;
    using Extensions;
    using ModestTree;

    #endregion

    internal class RandomStrategy<T> : ChooseStrategy<T> where T : class {
        public override T Get(IEnumerable<T> items) {
            if (items == null) {
                return null;
            }
            var filtered = Filter(items);
            if (filtered.IsEmpty()) {
                return null;
            }
            return filtered.Random();
        }

        protected virtual IEnumerable<T> Filter(IEnumerable<T> items) {
            return items;
        }
    }
}