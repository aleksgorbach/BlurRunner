// Created 24.12.2015
// Modified by  24.12.2015 at 9:46

namespace Assets.Scripts.Engine.Extensions {
    #region References

    using UnityEngine;

    #endregion

    public static class GameObjectExtensions {
        public static TInterface GetInterfaceComponent<TInterface>(this GameObject obj) where TInterface : class {
            return obj.GetComponent(typeof (TInterface)) as TInterface;
        }
    }
}