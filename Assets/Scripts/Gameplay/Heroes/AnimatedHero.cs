// Created 20.11.2015
// Modified by  25.11.2015 at 12:51

namespace Assets.Scripts.Gameplay.Heroes {
    #region References

    using Consts;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class AnimatedHero : Hero {
        [SerializeField]
        private Animator _animator;

        private bool _isOnObstacle;

        [Inject(Identifiers.Obstacles.Layer)]
        private string _obstaclesLayer;

        protected override void FixedUpdate() {
            base.FixedUpdate();
            _animator.SetBool("grounded", Grounded);
            _animator.SetFloat("speed", Speed);
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            if (_isOnObstacle) {
                return;
            }
            if (IsObstacleLayer(collision.gameObject.layer)) {
                _animator.SetTrigger("trip");
                _isOnObstacle = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision) {
            if (IsObstacleLayer(collision.gameObject.layer)) {
                _isOnObstacle = false;
            }
        }

        private bool IsObstacleLayer(int layer) {
            return _obstaclesLayer == LayerMask.LayerToName(layer);
        }

        public override void Kill() {
            base.Kill();
            _animator.SetTrigger("die");
        }
    }
}