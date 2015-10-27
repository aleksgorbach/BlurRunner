// Created 24.10.2015
// Modified by Александр 24.10.2015 at 21:25

namespace Assets.Scripts.Gameplay {
    using State.Levels;

    internal interface IGame {
        void StartLevel(ILevel level);
    }
}