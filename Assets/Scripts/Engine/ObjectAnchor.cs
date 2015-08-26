using UnityEngine;

namespace Assets.Scripts.Engine {
    public class ObjectAnchor : MonoBehaviour {

        [SerializeField]
        private Transform _anchoredObject;

        [SerializeField]
        private bool _xAnchor;

        [SerializeField]
        private bool _yAnchor;

        private Vector3 _initialPos;
        private Transform _transform;

        private void Awake() {
            _initialPos = transform.position;
            _transform = transform;
        }

        private void Update() {
            _transform.position = new Vector3(_xAnchor ? _anchoredObject.position.x : _initialPos.x, _yAnchor ? _anchoredObject.position.y : _initialPos.y, _initialPos.z);
        }
    }
}