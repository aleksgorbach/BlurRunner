// Created 15.10.2015
// Modified by Александр 02.11.2015 at 20:49

namespace Assets.Scripts.Engine.Pool {
    #region References

    using Factory.Strategy;

    #endregion

    internal interface IObjectPool<T> where T : class {
        T Get(IPoolStrategy<T> strategy);
        void Release(T obj);
    }
}