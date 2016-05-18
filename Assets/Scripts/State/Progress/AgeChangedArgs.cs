namespace Assets.Scripts.State.Progress {
    #region References

    using System;

    #endregion

    internal class AgeChangedArgs : EventArgs {
        public readonly float CurrentAge;

        public AgeChangedArgs(float currentAge) {
            CurrentAge = currentAge;
        }
    }
}