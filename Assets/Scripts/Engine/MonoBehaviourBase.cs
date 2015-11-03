// Created 22.10.2015 
// Modified by Gorbach Alex 03.11.2015 at 9:44

namespace Assets.Scripts.Engine {
    #region References

    using UnityEngine;

    #endregion

    internal abstract class MonoBehaviourBase : MonoBehaviour {
        private RectTransform _cachedRectTransform;
        private Transform _cachedTransform;

        public RectTransform rectTransform {
            get {
                return _cachedRectTransform ?? (_cachedRectTransform = transform as RectTransform);
            }
        }

        public new Transform transform {
            get {
                return _cachedTransform ?? (_cachedTransform = GetComponent<Transform>());
            }
        }

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