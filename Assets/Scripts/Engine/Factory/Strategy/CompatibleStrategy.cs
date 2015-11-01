// Created 01.11.2015
// Modified by Александр 01.11.2015 at 21:04

namespace Assets.Scripts.Engine.Factory.Strategy {
    #region References

    using System.Collections.Generic;
    using System.Linq;
    using Extensions;
    using Pool;

    #endregion

    internal class CompatibleStrategy {
        public T Get<T>(IEnumerable<T> items, T origin) where T : class, ICompatible<T> {
            return items.Where(x => x.IsCompatibleWith(origin)).Random();
        }
    }
}