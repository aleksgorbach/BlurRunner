// Created 02.11.2015 
// Modified by Gorbach Alex 02.11.2015 at 9:34

namespace Assets.Scripts.Gameplay.Bonuses.Implementations.Positive {
    #region References

    using UI;

    #endregion

    internal abstract class PositiveBonus : Bonus {
        protected override sealed int Direction {
            get {
                return 1;
            }
        }

        protected override float Force {
            get {
                return .1f;
            }
        }

        public override void Apply() {
        }
    }
}