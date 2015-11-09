// Created 04.11.2015
// Modified by Александр 08.11.2015 at 20:52

namespace Assets.Scripts.Engine.Factory.Strategy {
    #region References

    using System.Collections.Generic;
    using System.Linq;

    #endregion

    internal class FirstAvailableStrategy<T> : ChooseStrategy<T> {
        public override T Get(IEnumerable<T> items) {
            return items.First();
        }
    }
}