// Created 13.11.2015 
// Modified by Gorbach Alex 13.11.2015 at 14:53

namespace Assets.Scripts.Gameplay.Heroes {
    #region References

    using System;
    using Engine;
    using UnityEngine;

    #endregion

    internal class Foot : MonoBehaviourBase {
        public event Action Tripped;

        private void OnTripped() {
            var handler = Tripped;
            if (handler != null) {
                handler();
            }
        }

        private void OnTriggerEnter2D() {
            OnTripped();
        }
    }
}