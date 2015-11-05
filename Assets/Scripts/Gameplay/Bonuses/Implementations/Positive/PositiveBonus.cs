// Created 02.11.2015
// Modified by Александр 05.11.2015 at 20:36

namespace Assets.Scripts.Gameplay.Bonuses.Implementations.Positive {
    internal abstract class PositiveBonus : Bonus {
        protected override int Direction {
            get { return 1; }
        }

        protected override int Force {
            get { return 1; }
        }
    }
}