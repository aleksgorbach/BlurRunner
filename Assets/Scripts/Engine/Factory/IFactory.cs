// Created 20.10.2015
// Modified by  23.11.2015 at 12:38

namespace Assets.Scripts.Engine.Factory {
    #region References

    using System;
    using Zenject;

    #endregion

    #region References

    #endregion

    internal interface IFactory<out T>
        where T : class {
        T Create(IInstantiator instantiator);
        event Action Loaded;
    }
}