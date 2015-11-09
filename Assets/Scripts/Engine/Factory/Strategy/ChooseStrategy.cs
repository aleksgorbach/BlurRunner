// Created 08.11.2015
// Modified by Александр 08.11.2015 at 20:51

namespace Assets.Scripts.Engine.Factory.Strategy {
    #region References

    using System.Collections.Generic;

    #endregion

    internal abstract class ChooseStrategy<T> : MonoBehaviourBase, IChooseStrategy<T> {
        public abstract T Get(IEnumerable<T> items);
    }
}