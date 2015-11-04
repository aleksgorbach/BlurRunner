// Created 20.10.2015 
// Modified by Gorbach Alex 04.11.2015 at 13:31

namespace Assets.Scripts.Engine.Factory {
    #region References

    using Strategy;

    #endregion

    internal interface IFactory<T>
        where T : class {
        IChooseStrategy<T> Strategy { set; }

        T Create();
    }
}