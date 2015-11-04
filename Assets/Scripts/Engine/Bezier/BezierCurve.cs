// Created 04.11.2015 
// Modified by Gorbach Alex 04.11.2015 at 15:13

namespace Assets.Scripts.Engine.Bezier {
    #region References

    using UnityEngine;

    #endregion

    internal class BezierCurve {
        private readonly Vector2 _x;
        private readonly Vector2 _xTangent;
        private readonly Vector2 _yTangent;
        private readonly Vector2 _y;

        public BezierCurve(Vector2 x, Vector2 xTangent, Vector2 yTangent, Vector2 y) {
            _x = x;
            _xTangent = xTangent;
            _yTangent = yTangent;
            _y = y;
        }
    }
}