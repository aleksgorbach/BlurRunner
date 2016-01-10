// Created 20.10.2015
// Modified by  24.12.2015 at 12:32

namespace Assets.Scripts.Gameplay.Heroes {
    #region References

    using System;
    using Engine;
    using Engine.Extensions;
    using Engine.Moving;
    using Events;
    using JumpEngines;
    using Obstacles;
    using RunEngines;
    using State.Progress.Storage;
    using UnityEngine;
    using Zenject;

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

        #endregion

        [Inject]
        private IProgressStorage _progressStorage;

        [Inject]
        private IGame _game;

        [PostInject]
        private void PostInject() {
            _game.ProgressChanged += OnProgressChanged;
        }

        #region Interface

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
            Died.SafeInvoke(this, new HeroEventArgs(this));
        }

        public virtual void Win() {
            Stop();
        }

        #region Events

        public event EventHandler<HeroEventArgs> Died;

        #endregion

        #endregion

        private bool _isStubmled;
        private IMovingController _movingController;

        protected float Speed { get; private set; }

        protected bool Grounded { get; private set; }

        public Vector2 Position {
            get { return transform.position; }
        }


        private void FixedUpdate() {
            Grounded = Physics2D.OverlapCircle(_groundCheck.position, 10f, _groundLayer);
            if (Grounded && !_isStubmled) {
                Run();
            }
        }

        private void OnProgressChanged(object sender, GameProgressChangedArgs e) {
            _progressStorage.ActualAge += e.DeltaProgress;
        }

        private void Stop() {
            Speed = 0;
        }

        protected virtual void Run() {
            _runningEngine.Run(Speed);
        }


        protected virtual void Stumble(int damage, Action callback) {
            _isStubmled = true;
            _progressStorage.ActualAge -= damage/10f;
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
        }

        public class HeroEventArgs : EventArgs {
            public HeroEventArgs(Hero hero) {
                Hero = hero;
            }

            public Hero Hero { get; private set; }
        }
    }
}