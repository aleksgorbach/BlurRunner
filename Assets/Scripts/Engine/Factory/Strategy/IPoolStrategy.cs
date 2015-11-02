// Created 28.10.2015
// Modified by Александр 02.11.2015 at 20:46

namespace Assets.Scripts.Engine.Factory.Strategy {
    #region References

    using System.Collections.Generic;

    #endregion

    internal interface IPoolStrategy<T> where T : class {
        T Get(IEnumerable<T> items);
    }
}