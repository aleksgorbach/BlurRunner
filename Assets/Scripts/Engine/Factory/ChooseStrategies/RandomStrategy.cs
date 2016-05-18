// Created 30.11.2015
// Modified by  30.11.2015 at 10:06

namespace Assets.Scripts.Engine.Factory.ChooseStrategies {
    #region References

    using System.Collections.Generic;
    using Extensions;

    #endregion

    internal class RandomStrategy<T> : IChooseStrategy<T> where T : class {
        public T Choose(IEnumerable<T> items) {
            return items.Random();
        }
    }
}