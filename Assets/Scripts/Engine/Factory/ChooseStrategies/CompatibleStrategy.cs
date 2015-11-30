// Created 30.11.2015
// Modified by  30.11.2015 at 10:09

namespace Assets.Scripts.Engine.Factory.ChooseStrategies {
    #region References

    using System.Collections.Generic;
    using System.Linq;
    using Extensions;
    using Pool;

    #endregion

    internal class CompatibleStrategy<T> : IChooseStrategy<T> where T : class, ICompatible<T> {
        private T _lastChosen = null;

        public T Choose(IEnumerable<T> items) {
            _lastChosen = _lastChosen == null
                ? items.Random()
                : items.Where(item => item.IsCompatibleWith(_lastChosen)).Random();
            return _lastChosen;
        }
    }
}