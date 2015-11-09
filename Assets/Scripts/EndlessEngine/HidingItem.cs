// Created 09.11.2015 
// Modified by Gorbach Alex 09.11.2015 at 8:54

namespace Assets.Scripts.EndlessEngine {
    #region References

    using System;
    using Engine;
    using UnityEngine;

    #endregion

    [RequireComponent(typeof(Collider2D))]
    internal abstract class HidingItem<T> : MonoBehaviourBase, IRemovable {
        protected abstract T Instance { get; }

        public void Remove() {
            var handler = NeedRemove;
            if (handler != null) {
                handler.Invoke(Instance);
            }
        }

        public event Action<T> NeedRemove;
    }
}