// Created 14.12.2015
// Modified by  14.12.2015 at 12:56

namespace Assets.Scripts.Gameplay.Heroes.RunEngines {
    #region References

    using UnityEngine;

    #endregion

    internal class WheelRunningEngine : HeroRunningEngine {
        [SerializeField]
        private Rigidbody2D _rigidbody;

        private float _speed;

        [SerializeField]
        private HingeJoint2D _wheel;


        public override void Run(float speed) {
            _speed = speed;
        }

        private void FixedUpdate() {
            //for (var i = 0; i < _wheels.Length; i++) {
            //    var motor = _wheels[i].motor;
            //    motor.motorSpeed = _speed;
            //}
            var motor = _wheel.motor;
            motor.motorSpeed = _speed;
        }

        public override bool Reached(float destination) {
            return _rigidbody.position.x >= destination;
        }
    }
}