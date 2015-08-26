using UnityEngine;

namespace Assets.Scripts.Engine.Moving {

    [RequireComponent(typeof(CharacterController))]
    internal class CharacterMoving : HeroMovingController {
        private CharacterController _controller;

        protected override void Awake() {
            base.Awake();
            _controller = GetComponent<CharacterController>();
        }

        protected override void Run() {
            _controller.SimpleMove(_runVector);
        }

        protected override void Jump() {;
            _controller.Move(_jumpVector);
        }
    }
}
