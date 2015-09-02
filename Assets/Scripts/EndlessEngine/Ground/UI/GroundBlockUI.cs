using Assets.Scripts.EndlessEngine.Interfaces;
using UnityEngine;

namespace Assets.Scripts.EndlessEngine.Ground.UI {
    [RequireComponent(typeof (Collider2D))]
    internal class GroundBlockUI : MonoBehaviour, IHiding {
        private Camera _camera;
        private Collider2D _collider;
        private bool _isDestroying;
        public IGroundBlock Block { get; private set; }

        public float Edge {
            get {
                var rectTransform = GetComponent<RectTransform>();
                return rectTransform.anchoredPosition.x + rectTransform.sizeDelta.x;
            }
        }

        public event HidingDelegate BecameInvisible;

        public bool IsVisible {
            get {
                return GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(_camera),
                    _collider.bounds);
            }
        }

        public float Length { get; private set; }

        private void Awake() {
            _collider = GetComponent<Collider2D>();
            Length = _collider.bounds.size.x;
            _camera = Camera.main;
        }

        public void Init(IGroundBlock block) {
            Block = block;
        }

        private void Update() {
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