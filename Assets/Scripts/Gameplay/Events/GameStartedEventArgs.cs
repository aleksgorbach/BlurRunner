namespace Assets.Scripts.Gameplay.Events {
    #region References

    using System;
    using Heroes;
    using State.Levels;

    #endregion

    internal class GameStartedEventArgs : EventArgs {
        public readonly ILevel Level;
        public readonly Hero Hero;

        public GameStartedEventArgs(ILevel level, Hero hero) {
            Level = level;
            Hero = hero;
        }
    }
}