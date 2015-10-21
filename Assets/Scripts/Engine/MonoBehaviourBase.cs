// Created 21.10.2015
// Modified by Александр 21.10.2015 at 19:43

namespace Assets.Scripts.Engine {
    #region References

    using UnityEngine;

    #endregion

    internal abstract class MonoBehaviourBase : MonoBehaviour {
        public TInterface GetInterfaceComponent<TInterface>() where TInterface : class {
            return GetComponent(typeof (TInterface)) as TInterface;
        }
    }
}