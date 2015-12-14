// Created 14.12.2015
// Modified by  14.12.2015 at 12:56

namespace Assets.Scripts.Gameplay.Heroes.RunEngines {
    #region References

    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    #endregion

    internal class WheelRunningEngine : HeroRunningEngine {
        [SerializeField]
        private Rigidbody2D _rigidbody;

        private float _speed;
        private List<Wheel> _wheels;

        public override void Run(float speed) {
            _wheels = _rigidbody.GetComponentsInChildren<HingeJoint2D>().Select(x => new Wheel(x, x.motor)).ToList();
            _speed = speed;
        }

        private void FixedUpdate() {
            for (var i = 0; i < _wheels.Count; i++) {
                _wheels[i].Motor.motorSpeed = _speed;
                _wheels[i].Joint.motor = _wheels[i].Motor;
            }
        }

        public override bool Reached(float destination) {
            return _rigidbody.position.x >= destination;
        }

        private class Wheel {
            public readonly HingeJoint2D Joint;
            public JointMotor2D Motor;

            public Wheel(HingeJoint2D joint, JointMotor2D motor) {
                Joint = joint;
                Motor = motor;
            }
        }
    }
}