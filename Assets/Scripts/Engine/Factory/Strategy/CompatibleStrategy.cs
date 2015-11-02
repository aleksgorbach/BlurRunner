// Created 01.11.2015
// Modified by Александр 02.11.2015 at 21:06

namespace Assets.Scripts.Engine.Factory.Strategy {
    #region References

    using System.Collections.Generic;
    using System.Linq;
    using Extensions;
    using Pool;

    #endregion

    internal class CompatibleStrategy<T> : IPoolStrategy<T> where T : class, ICompatible<T> {
        private T _origin;

        public T Get(IEnumerable<T> items) {
            return items.Where(x => x.IsCompatibleWith(_origin)).Random();
        }

        public void SetOrigin(T origin) {
            _origin = origin;
        }
    }
}