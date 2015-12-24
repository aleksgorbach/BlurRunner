// Created 02.11.2015
// Modified by  24.12.2015 at 9:19

namespace Assets.Scripts.Engine.Moving {
    internal interface IMovable {
        void Run(float runForce);
        void Jump(float jumpForce);
    }
}