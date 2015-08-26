using UnityEngine;

namespace Assets.Scripts.Gameplay.Heroes {
    [RequireComponent(typeof(Animator))]
    internal class Hero : MonoBehaviour {
        private Animator _animator;

        private void Awake() {
            _animator = GetComponent<Animator>();
        }

        public void StartMoving() {
            _animator.SetTrigger("run_trigger");
        }
    }
}