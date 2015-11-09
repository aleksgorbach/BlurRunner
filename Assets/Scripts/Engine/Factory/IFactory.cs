// Created 04.11.2015
// Modified by Александр 08.11.2015 at 20:38

namespace Assets.Scripts.Engine.Factory {
    #region References

    

    #endregion

    internal interface IFactory<out T>
        where T : class {
        T Create();
    }
}