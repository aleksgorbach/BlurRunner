// Created 20.10.2015
// Modified by  30.11.2015 at 9:04

namespace Assets.Scripts.Engine.Factory {

    #region References

    #endregion

    #region References

    #endregion

    internal interface IFactory<T>
        where T : class {
        void Init(T[] prefabs, IChooseStrategy<T> strategy);
    }
}