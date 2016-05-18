namespace Assets.Scripts.Gameplay.Events {
    using System;
    class GameProgressChangedArgs : EventArgs {
        public readonly float Progress;
        public readonly float DeltaProgress;

        public GameProgressChangedArgs(float progress, float deltaProgress) {
            Progress = progress;
            DeltaProgress = deltaProgress;
        }
    }
}