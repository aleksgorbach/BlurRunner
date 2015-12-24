// Created 20.10.2015
// Modified by  24.12.2015 at 12:32

namespace Assets.Scripts.Gameplay.Heroes {
    #region References

    using System;
    using Engine;
    using Engine.Extensions;
    using Engine.Moving;
    using JumpEngines;
    using Obstacles;
    using RunEngines;
    using UnityEngine;

    #endregion

    [RequireComponent(typeof (MovingController))]
    internal class Hero : MonoBehaviourBase, IMovable {
        #region Visible in inspector

        [SerializeField]
        private Transform _groundCheck;

        [SerializeField]
        private LayerMask _groundLayer;

        [SerializeField]
        private HeroJumpingEngine _jumpingEngine;


        [SerializeField]
        private HeroRunningEngine _runningEngine;

        [SerializeField]
        private int _startHealth = 5;

        #endregion

        private int _health;

        private bool _isStubmled;

        private IMovingController _movingController;

        protected float Speed { get; private set; }

        protected bool Grounded { get; private set; }

        public int Health {
            get { return _health; }
            private set {
                if (_health != value) {
                    var prev = _health;
                    _health = Mathf.Max(value, 0);
                    OnHealthChanged(prev, _health);
                    if (_health <= 0) {
                        Die();
                    }
                }
            }
        }

        public void Jump(float jumpForce) {
            if (Grounded && !_isStubmled) {
                _jumpingEngine.Jump(jumpForce);
            }
        }

        public void Run(float speed) {
            Speed = speed;
        }


        public virtual void Die() {
            Stop();
            var handler = Died;
            if (handler != null) {
                handler();
            }
        }

        private void OnHealthChanged(float previousHealth, float currentHealth) {
            var handler = HealthChanged;
            if (handler != null) {
                handler.Invoke(previousHealth, currentHealth);
            }
        }

        #region Events

        public event Action Died;

        /// <summary>
        /// Fire when health changed, arguments are <i>previous health</i> and <i>current health</i>
        /// </summary>
        public event Action<float, float> HealthChanged;

        #endregion

        private void FixedUpdate() {
            Grounded = Physics2D.OverlapCircle(_groundCheck.position, 10f, _groundLayer);
            if (Grounded && !_isStubmled) {
                Run();
            }
        }

        private void Stop() {
            Speed = 0;
        }

        protected virtual void Run() {
            _runningEngine.Run(Speed);
        }

        public virtual void Congratulate() {
            Stop();
        }

        protected virtual void Stumble(int damage, Action callback) {
            _isStubmled = true;
            Health -= damage;
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            if (_isStubmled) {
                return;
            }
            var danger = collision.gameObject.GetInterfaceComponent<IDanger>();
            if (danger != null) {
                Stumble(danger.Damage, OnStumbleEnded);
            }
        }

        private void OnStumbleEnded() {
            _isStubmled = false;
        }

        protected override void Awake() {
            base.Awake();
            _movingController = GetInterfaceComponent<IMovingController>();
            _movingController.RegisterMovable(this);
            _health = _startHealth;
        }

        public class HeroSpawnedEventArgs : EventArgs {
            public HeroSpawnedEventArgs(Hero hero) {
                Hero = hero;
            }

            public Hero Hero { get; private set; }
        }
    }
}