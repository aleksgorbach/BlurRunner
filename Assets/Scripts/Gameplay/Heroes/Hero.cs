using UnityEngine;

namespace Assets.Scripts.Gameplay.Heroes {
    internal class Hero : MonoBehaviour {
        [SerializeField]
        private Rigidbody2D _rigidbody;
        [SerializeField]
        private float _speed;

        private void Update() {
            _rigidbody.AddForce(new Vector2(_speed, 0));
        }
    }
}