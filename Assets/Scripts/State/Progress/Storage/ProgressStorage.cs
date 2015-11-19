// Created 22.10.2015
// Modified by  19.11.2015 at 15:09

namespace Assets.Scripts.State.Progress.Storage {

    #region References

    #endregion

    internal class ProgressStorage : IProgressStorage {
        public ProgressStorage() {
            SetCurrentLevel(0);
        }


        public int CurrentLevel { get; private set; }

        public void SetCurrentLevel(int number) {
            CurrentLevel = number;
        }
    }
}