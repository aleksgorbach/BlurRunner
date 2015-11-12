// Created 20.10.2015 
// Modified by Gorbach Alex 12.11.2015 at 11:34

namespace Assets.Scripts.Engine.Factory {
    #region References

    using Zenject;

    #endregion

    #region References

    #endregion

    internal interface IFactory<out T>
        where T : class {
        T Create(IInstantiator instantiator);
    }
}