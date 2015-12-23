// Created 20.11.2015
// Modified by  22.12.2015 at 10:00

namespace Assets.Scripts.Gameplay.Heroes {
    #region References

    using System;
    using System.Collections;
    using UnityEngine;

    #endregion

    internal class AnimatedHero : Hero {
        [SerializeField]
        private Animator _animator;

        protected override void Run() {
            base.Run();
            _animator.SetBool("grounded", Grounded);
            _animator.SetFloat("speed", Speed);
        }


        public override void Die() {
            base.Die();
            _animator.SetTrigger("die");
        }

        protected override void Stumble(Action callback) {
            base.Stumble(callback);
            _animator.SetTrigger("trip");
            var clip = _animator.GetCurrentAnimatorClipInfo(0)[0].clip;
            StartCoroutine(StumbleCoroutine(clip.length*1.4f, callback));
        }

        private IEnumerator StumbleCoroutine(float duration, Action callback) {
            yield return new WaitForSeconds(duration);
            callback();
        }
    }
}