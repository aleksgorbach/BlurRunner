// Created 22.10.2015
// Modified by Александр 26.10.2015 at 20:58

namespace Assets.Scripts.EndlessEngine.Ground.UI {
    #region References

    using Engine;
    using Interfaces;
    using UnityEngine;

    #endregion

    [RequireComponent(typeof (Collider2D))]
    internal class GroundBlockUI : MonoBehaviourBase, IHiding {
        private Camera _camera;
        private Collider2D _collider;
        private bool _isDestroying;

        [SerializeField]
        private Transform _treeContainer;

        public IGroundBlock Block { get; private set; }

        public float Edge {
            get { return rectTransform.anchoredPosition.x + rectTransform.sizeDelta.x; }
        }

        public float Length { get; private set; }

        public Transform TreeContainer {
            get { return _treeContainer; }
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

        public void Init(IGroundBlock block) {
            Block = block;
        }

        private void OnEnable() {
            _isDestroying = false;
        }

        private void OnDisable() {
            _isDestroying = true;
        }
    }
}