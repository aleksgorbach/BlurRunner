// Created 02.11.2015 
// Modified by Gorbach Alex 04.11.2015 at 13:52

namespace Assets.Scripts.Engine.Factory.Strategy {
    #region References

    using System.Collections.Generic;
    using System.Linq;
    using Pool;

    #endregion

    internal class CompatibleStrategy<T> : RandomStrategy<T>
        where T : class, ICompatible<T> {
        private T _origin;

        public override T Get(IEnumerable<T> items) {
            var created = base.Get(items);
            _origin = created;
            return created;
        }

        protected override IEnumerable<T> Filter(IEnumerable<T> items) {
            return base.Filter(items).Where(x => _origin == null || _origin.IsCompatibleWith(x));
        }
    }
}