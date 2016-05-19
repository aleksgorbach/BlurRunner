namespace Assets.Scripts.Gameplay.Heroes {
    #region References

    using System;
    using Effects.Vibro;
    using Engine;
    using Engine.Extensions;
    using Engine.Input;
    using JumpEngines;
    using Obstacles;
    using RunEngines;
    using StateBehaviours;
    using UnityEngine;
    using Zenject;

    #endregion

    [RequireComponent(typeof (Animator))]
    internal class Hero : MonoBehaviourBase {
        private static class Keys {
            public const string Grounded = "grounded";
            public const string SpeedX = "speedX";
            public const string SpeedY = "speedY";
            public const string Died = "die";
            public const string Win = "win";
            public const string Stumbled = "trip";
        }

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

        #region Injected dependencies

        [Inject]
        private IInputController _controller;

        [Inject]
        private VibroManager _vibroManager;

        #endregion

        #region Interface

        public float NominalSpeed {
            get { return _runningEngine.Force; }
        }

        public void Die() {
            Stop();
            _animator.SetTrigger(Keys.Died);
        }

        public void Win() {
            Stop();
            _animator.SetTrigger(Keys.Win);
        }

        public Vector2 Speed {
            get { return _runningEngine.Speed; }
        }

        #region Events

        public event EventHandler<HeroEventArgs> Died;
        public event EventHandler<HeroEventArgs> Stumbled;

        #endregion

        #endregion

        private Animator _animator;

        #region State handlers

        private void OnRunStateEntered(object sender, StateEventArgs e) {
            _isRunning = true;
        }

        private void OnStopRunning(object sender, StateEventArgs e) {
            _isRunning = false;
        }

        private void OnJumpStateEntered(object sender, StateEventArgs e) {
            _jumpingEngine.Jump();
        }

        private void OnDieStateEntered(object sender, StateEventArgs e) {
            Died.SafeInvoke(this, new HeroEventArgs(this));
        }

        private void OnStumbleStateEntered(object sender, StateEventArgs e) {
            Stumbled.SafeInvoke(this, new HeroEventArgs(this));
            _vibroManager.Play(null);
        }

        #endregion

        private void InitBehaviours() {
            RegisterHandler<RunStateBehaviour>(OnRunStateEntered).Exited += OnStopRunning;
            RegisterHandler<JumpStateBehaviour>(OnJumpStateEntered);
            RegisterHandler<DiedStateBehaviour>(OnDieStateEntered);
            RegisterHandler<StumbledStateBehaviour>(OnStumbleStateEntered);
        }


        private TStateBehaviour RegisterHandler<TStateBehaviour>(EventHandler<StateEventArgs> handler)
            where TStateBehaviour : HeroStateBehaviour {
            var behaviour = _animator.GetBehaviour<TStateBehaviour>();
            behaviour.StateEntered += handler;
            return behaviour;
        }


        private bool _grounded;
        private bool _isRunning;

        [PostInject]
        private void PostInject() {
            _controller.Click += Jump;
        }

        protected override void Update() {
            base.Update();
            _grounded = Physics2D.OverlapCircle(_groundCheck.position, 10f, _groundLayer);
            _animator.SetBool(Keys.Grounded, _grounded);
            _animator.SetFloat(Keys.SpeedX, Speed.x);
            _animator.SetFloat(Keys.SpeedY, Speed.y);
            if (_isRunning) {
                _runningEngine.Run();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            var danger = collision.gameObject.GetInterfaceComponent<IDanger>();
            if (danger != null) {
                Stumble();
            }
        }

        private void Stop() {
            _runningEngine.Stop();
        }


        private void Jump(Vector2 screenPos) {
            if (_isRunning) {
                _jumpingEngine.Jump();
            }
        }

        private void Stumble() {
            if (_isRunning) {
                _animator.SetTrigger(Keys.Stumbled);
                _isRunning = false;
            }
        }


        protected override void Awake() {
            base.Awake();
            _animator = GetComponent<Animator>();
            InitBehaviours();
        }

        public class HeroEventArgs : EventArgs {
            public HeroEventArgs(Hero hero) {
                Hero = hero;
            }

            public Hero Hero { get; private set; }
        }
    }
}