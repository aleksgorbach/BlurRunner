// Created 14.12.2015
// Modified by  21.01.2016 at 10:57

namespace Assets.Scripts.Gameplay.Heroes.RunEngines {
    #region References

    using UnityEngine;

    #endregion

    internal class WheelRunningEngine : HeroRunningEngine {
        private JointMotor2D _motor;

        [SerializeField]
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private HingeJoint2D _wheel;

        protected override void Awake() {
            base.Awake();
            _motor = _wheel.motor;
        }

        public override void Run() {
            _motor.motorSpeed = Force;
        }

        public override Vector2 Speed {
            get { return _rigidbody.velocity; }
        }
    }
}