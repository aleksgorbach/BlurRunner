// Created 02.11.2015
// Modified by Александр 02.11.2015 at 19:57

namespace Assets.Scripts.Gameplay.Bonuses.Implementations.Positive {
    internal abstract class PositiveBonus : Bonus {
        protected override int Direction {
            get { return 1; }
        }

        protected override float Force {
            get { return .1f; }
        }
    }
}