// Created 26.10.2015
// Modified by Александр 26.10.2015 at 21:04

namespace Assets.Scripts.EndlessEngine.Ground.Decorations.UI {
    #region References

    using Engine;
    using Interfaces;
    using UnityEngine;

    #endregion

    internal class DecorationItemUI : MonoBehaviourBase, IHiding {
        private Camera _camera;
        private Collider2D _collider;

        public bool IsVisible {
            get {
                return GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(_camera), _collider.bounds);
            }
        }

        protected override void Awake() {
            base.Awake();
            _collider = GetComponent<Collider2D>();
            _camera = Camera.main;
        }
    }
}