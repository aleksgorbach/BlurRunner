// Created 22.10.2015
// Modified by Александр 22.10.2015 at 20:57

namespace Assets.Scripts.Engine {
    #region References

    using UnityEngine;

    #endregion

    internal abstract class MonoBehaviourBase : MonoBehaviour {
        public RectTransform rectTransform { get; private set; }
        public new Transform transform { get; private set; }

        protected virtual void Awake() {
            transform = GetComponent<Transform>();
            rectTransform = GetComponent<RectTransform>();
        }

        protected virtual void Start() {
        }

        protected virtual void Update() {
        }

        protected virtual void OnDestroy() {
        }

        public TInterface GetInterfaceComponent<TInterface>() where TInterface : class {
            return GetComponent(typeof (TInterface)) as TInterface;
        }
    }
}