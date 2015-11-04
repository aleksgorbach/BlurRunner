// Created 20.10.2015 
// Modified by Gorbach Alex 04.11.2015 at 10:57

namespace Assets.Scripts.EndlessEngine.Ground.UI {
    #region References

    using Engine;
    using Engine.Pool;
    using Interfaces;
    using UnityEngine;

    #endregion

    [RequireComponent(typeof(Collider2D))]
    internal class GroundBlock : MonoBehaviourBase, IHiding, IGroundBlock, ICompatible<GroundBlock> {
        private Camera _camera;
        private Collider2D _collider;

        [SerializeField]
        private Transform _treeContainer;

        [SerializeField]
        private BorderLevel _leftLevel;

        [SerializeField]
        private BorderLevel _rightLevel;

        public float Edge {
            get {
                return rectTransform.anchoredPosition.x + rectTransform.sizeDelta.x;
            }
        }

        public float Length { get; private set; }

        public Transform TreeContainer {
            get {
                return _treeContainer;
            }
        }

        public bool IsCompatibleWith(GroundBlock other) {
            if (other == null) {
                return true;
            }
            return _rightLevel == other._leftLevel;
        }

        public bool IsVisible {
            get {
                return GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(_camera), _collider.bounds);
            }
        }

        protected override void Awake() {
            base.Awake();
            _collider = GetComponent<Collider2D>();
            Length = _collider.bounds.size.x;
            _camera = Camera.main;
        }
    }
}