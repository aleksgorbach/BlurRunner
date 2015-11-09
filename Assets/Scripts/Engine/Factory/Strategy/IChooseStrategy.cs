// Created 04.11.2015
// Modified by Александр 08.11.2015 at 20:37

namespace Assets.Scripts.Engine.Factory.Strategy {
    #region References

    using System.Collections.Generic;

    #endregion

    internal interface IChooseStrategy<T> {
        T Get(IEnumerable<T> items);
    }
}