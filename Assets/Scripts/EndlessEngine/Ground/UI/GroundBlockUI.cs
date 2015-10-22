// Created 20.10.2015 
// Modified by Gorbach Alex 22.10.2015 at 15:53

namespace Assets.Scripts.EndlessEngine.Ground.UI {
    #region References

    using Interfaces;
    using Engine;
    using UnityEngine;

    #endregion

    [RequireComponent(typeof(Collider2D))]
    internal class GroundBlockUI : MonoBehaviourBase, IHiding {
        private Camera _camera;
        private Collider2D _collider;
        private bool _isDestroying;

        [SerializeField]
        private Transform _treeContainer;

        public IGroundBlock Block { get; private set; }

        public float Edge {
            get {
                var rectTransform = GetComponent<RectTransform>();
                return rectTransform.anchoredPosition.x + rectTransform.sizeDelta.x;
            }
        }

        public float Length { get; private set; }

        public Transform TreeContainer {
            get {
                return _treeContainer;
            }
        }

        public bool IsVisible {
            get {
                return GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(_camera), _collider.bounds);
            }
        }

        public event HidingDelegate BecameInvisible;

        protected override void Awake() {
            base.Awake();
            _collider = GetComponent<Collider2D>();
            Length = _collider.bounds.size.x;
            _camera = Camera.main;
        }

        public void Init(IGroundBlock block) {
            Block = block;
        }

        protected override void Update() {
            base.Update();
            if (_isDestroying) {
                return;
            }
            //var inFrustum = GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(_camera),
            //    _collider.bounds);
            //if (!inFrustum) {
            //    OnBecameInvisible();
            //}
        }

        private void OnBecameInvisible() {
            if (BecameInvisible != null) {
                BecameInvisible(this);
            }
        }

        private void OnEnable() {
            _isDestroying = false;
        }

        private void OnDisable() {
            _isDestroying = true;
        }
    }
}