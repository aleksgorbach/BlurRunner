namespace Assets.Scripts.State.Progress {
    #region References

    using System;

    #endregion

    internal class ProgressChangedArgs : EventArgs {
        public readonly float DeltaAge;

        public ProgressChangedArgs(float delta) {
            DeltaAge = delta;
        }
    }
}