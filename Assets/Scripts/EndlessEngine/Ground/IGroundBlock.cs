// Created 15.10.2015
// Modified by Александр 25.10.2015 at 18:15

namespace Assets.Scripts.EndlessEngine.Ground {
    internal enum BorderLevel {
        Bottom,
        Middle,
        Top
    }

    internal interface IGroundBlock {
        BorderLevel LeftBorderLevel { get; }
        BorderLevel RightBorderLevel { get; }
    }
}