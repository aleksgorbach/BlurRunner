// Created 14.12.2015
// Modified by  22.12.2015 at 10:40

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

        public override void Run(float speed) {
            _motor.motorSpeed = speed;
        }
    }
}