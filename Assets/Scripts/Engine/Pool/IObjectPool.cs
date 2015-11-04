// Created 20.10.2015 
// Modified by Gorbach Alex 04.11.2015 at 13:01

namespace Assets.Scripts.Engine.Pool {
    #region References

    using Factory.Strategy;

    #endregion

    internal interface IObjectPool<T>
        where T : class {
        IChooseStrategy<T> Strategy { get; }

        T Get();

        void Release(T obj);
    }
}