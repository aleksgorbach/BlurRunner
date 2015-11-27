// Created 20.10.2015
// Modified by  27.11.2015 at 9:12

namespace Assets.Scripts.Engine.Factory {

    #region References

    #endregion

    #region References

    #endregion

    internal interface IFactory<in T>
        where T : class {
        void Init(T[] prefabs);
    }
}