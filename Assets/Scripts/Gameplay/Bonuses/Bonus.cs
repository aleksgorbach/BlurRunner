// Created 28.10.2015 
// Modified by Gorbach Alex 02.11.2015 at 9:32

namespace Assets.Scripts.Gameplay.Bonuses {
    #region References

    using UI;

    #endregion

    internal abstract class Bonus : IBonus {
        protected abstract int Direction { get; }
        protected abstract float Force { get; }

        public float Strength {
            get {
                return Force * Direction;
            }
        }

        public abstract void Apply();
    }
}