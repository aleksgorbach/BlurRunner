// Created 29.10.2015 
// Modified by Gorbach Alex 29.10.2015 at 10:40

namespace Assets.Scripts.Engine.Moving {
    using UnityEngine;

    internal interface IMovable {
        Vector2 Velocity { get;set; }
        void Run(float runForce);
        void Jump(float jumpForce);
    }
}