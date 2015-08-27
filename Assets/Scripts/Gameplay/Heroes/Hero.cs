using UnityEngine;

namespace Assets.Scripts.Gameplay.Heroes {
    [RequireComponent(typeof(Animator))]
    internal class Hero : MonoBehaviour {
        [SerializeField]
        private Rigidbody2D _rigidbody;
        [SerializeField]
        private float _speed;

        private Animator _animator;

        private void Awake() {
            _animator = GetComponent<Animator>();
        }

        public void StartMoving() {
            //_animator.SetTrigger("run_trigger");
            _rigidbody.AddForce(new Vector2(_speed, 0));
        }
    }
}