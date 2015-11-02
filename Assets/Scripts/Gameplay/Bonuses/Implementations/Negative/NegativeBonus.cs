// Created 02.11.2015
// Modified by Александр 02.11.2015 at 19:59

namespace Assets.Scripts.Gameplay.Bonuses.Implementations.Negative {
    internal abstract class NegativeBonus : Bonus {
        protected override int Direction {
            get { return -1; }
        }

        protected override float Force {
            get { return .1f; }
        }
    }
}