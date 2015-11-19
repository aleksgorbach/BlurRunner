// Created 19.11.2015
// Modified by Александр 19.11.2015 at 21:40

namespace Assets.Scripts.Gameplay.Heroes {
    #region References

    using UnityEngine;

    #endregion

    [RequireComponent(typeof (Animator))]
    internal class AnimatedHero : Hero {
        private Animator _animator;

        protected override void Awake() {
            base.Awake();
            _animator = GetComponent<Animator>();
        }

        protected override void FixedUpdate() {
            base.FixedUpdate();
            _animator.SetBool("grounded", Grounded);
            _animator.SetFloat("speed", Speed);
        }
    }
}