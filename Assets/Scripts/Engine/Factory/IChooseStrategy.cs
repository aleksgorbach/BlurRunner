// Created 30.11.2015
// Modified by  30.11.2015 at 8:46

namespace Assets.Scripts.Engine.Factory {
    #region References

    using System.Collections.Generic;

    #endregion

    internal interface IChooseStrategy<T> {
        T Choose(IEnumerable<T> items);
    }
}