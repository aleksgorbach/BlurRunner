// Created 04.11.2015
// Modified by Александр 08.11.2015 at 20:51

namespace Assets.Scripts.Engine.Factory.Strategy {
    #region References

    using System.Collections.Generic;
    using Extensions;

    #endregion

    internal class RandomStrategy<T> : ChooseStrategy<T> where T : class {
        public override T Get(IEnumerable<T> items) {
            return Filter(items).Random();
        }

        protected virtual IEnumerable<T> Filter(IEnumerable<T> items) {
            return items;
        }
    }
}