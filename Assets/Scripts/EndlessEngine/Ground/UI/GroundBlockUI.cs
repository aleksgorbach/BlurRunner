using Assets.Scripts.EndlessEngine.Interfaces;
using UnityEngine;

namespace Assets.Scripts.EndlessEngine.Ground.UI {
    [RequireComponent(typeof (Collider2D))]
    internal class GroundBlockUI : MonoBehaviour, IHiding {
        private Camera _camera;
        private Collider2D _collider;
        private bool _isDestroying;
        public IGroundBlock Block { get; private set; }
        public float Length { get; private set; }
        public event HidingDelegate BecameInvisible;

        private void Awake() {
            _collider = GetComponent<Collider2D>();
            Length = _collider.bounds.size.x;
            _camera = Camera.main;
        }

        public void Init(IGroundBlock block) {
            Block = block;
        }

        private void Update() {
            if (!_isDestroying &&
                !GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(_camera), _collider.bounds)) {
                OnBecameInvisible();
            }
        }

        private void OnBecameInvisible() {
            _isDestroying = true;
            if (BecameInvisible != null) {
                BecameInvisible(this);
            }
        }
    }
}