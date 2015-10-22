// Created 20.10.2015 
// Modified by Gorbach Alex 22.10.2015 at 15:31

namespace Assets.Scripts.Engine.Physics {
    #region References

    using UnityEngine;

    #endregion

    [RequireComponent(typeof(Rigidbody2D))]
    internal class CenterOfMass : MonoBehaviourBase {
        [SerializeField]
        private RectTransform _centerOfMass;

        protected override void Awake() {
            base.Awake();
            GetComponent<Rigidbody2D>().centerOfMass = _centerOfMass.anchoredPosition;
        }
    }
}