// Created 14.12.2015
// Modified by  22.12.2015 at 10:40

namespace Assets.Scripts.Gameplay.Heroes.RunEngines {
    #region References

    using UnityEngine;

    #endregion

    internal class WheelRunningEngine : HeroRunningEngine {
        [SerializeField]
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private HingeJoint2D _wheel;


        private void FixedUpdate() {
            if (Running) {
                var motor = _wheel.motor;
                motor.motorSpeed = Speed;
            }
        }
    }
}