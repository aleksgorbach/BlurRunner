// Created 29.10.2015
// Modified by Александр 01.11.2015 at 12:30

namespace Assets.Scripts.Engine.Moving {
    internal abstract class Movable : MonoBehaviourBase {
        public abstract void Run(float runForce);
        public abstract void Jump(float jumpForce);
    }
}