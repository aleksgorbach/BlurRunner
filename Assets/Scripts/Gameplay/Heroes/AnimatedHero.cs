// Created 20.11.2015
// Modified by  20.01.2016 at 13:02

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
            _animator.SetFloat("speed", Speed.x);
        }


        public override void Die() {
            base.Die();
            _animator.SetTrigger("die");
        }

        protected override void Stumble(int damage, Action callback) {
            base.Stumble(damage, callback);
            _animator.SetTrigger("trip");
            var clip = _animator.GetCurrentAnimatorClipInfo(0)[0].clip;
            StartCoroutine(StumbleCoroutine(clip.length, callback));
        }

        private IEnumerator StumbleCoroutine(float duration, Action callback) {
            yield return new WaitForSeconds(duration);
            callback();
        }
    }
}