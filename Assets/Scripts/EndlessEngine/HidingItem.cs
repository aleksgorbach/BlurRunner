// Created 30.10.2015 
// Modified by Gorbach Alex 30.10.2015 at 14:54

namespace Assets.Scripts.EndlessEngine {
    #region References

    using Interfaces;
    using Engine;
    using UnityEngine;
    using Zenject;

    #endregion

    [RequireComponent(typeof(Collider2D))]
    internal abstract class HidingItem : MonoBehaviourBase, IHiding {
        protected Collider2D _collider;

        [Inject]
        private Camera _camera;

        public bool IsVisible {
            get {
                return GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(_camera), _collider.bounds);
            }
        }

        protected override void Awake() {
            base.Awake();
            _collider = GetComponent<Collider2D>();
        }
    }
}