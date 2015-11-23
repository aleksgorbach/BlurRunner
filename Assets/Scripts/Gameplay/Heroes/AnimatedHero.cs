// Created 20.11.2015
// Modified by  23.11.2015 at 15:38

namespace Assets.Scripts.Gameplay.Heroes {
    #region References

    using Consts;
    using UnityEngine;
    using Zenject;

    #endregion

    [RequireComponent(typeof (Animator))]
    internal class AnimatedHero : Hero {
        private Animator _animator;

        [Inject(Identifiers.Obstacles.Layer)]
        private string _obstaclesLayer;

        protected override void Awake() {
            base.Awake();
            _animator = GetComponent<Animator>();
        }

        protected override void FixedUpdate() {
            base.FixedUpdate();
            _animator.SetBool("grounded", Grounded);
            _animator.SetFloat("speed", Speed);
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            if (_obstaclesLayer == LayerMask.LayerToName(collision.gameObject.layer)) {
                _animator.SetTrigger("trip");
            }
        }
    }
}