// Created 02.11.2015
// Modified by  14.12.2015 at 14:32

namespace Assets.Scripts.Gameplay.Bonuses.Implementations.Negative {
    internal abstract class NegativeBonus : Bonus {
        protected override int Direction {
            get { return -1; }
        }

        protected override int Force {
            get { return 1; }
        }
    }
}