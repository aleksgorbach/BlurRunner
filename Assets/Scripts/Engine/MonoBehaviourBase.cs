// Created 22.10.2015 
// Modified by Gorbach Alex 22.10.2015 at 12:42

namespace Assets.Scripts.Engine {
    #region References

    using UnityEngine;

    #endregion

    internal abstract class MonoBehaviourBase : MonoBehaviour {
        protected virtual void Awake() {
        }

        protected virtual void Start() {
        }

        protected virtual void Update() {
        }

        protected virtual void OnDestroy() {
        }

        public TInterface GetInterfaceComponent<TInterface>() where TInterface : class {
            return GetComponent(typeof(TInterface)) as TInterface;
        }
    }
}