// Created 14.01.2016
// Modified by  19.01.2016 at 15:59

namespace Assets.Scripts.State.Progress.Storage {

    #region References

    #endregion

    internal interface IProgressStorage {
        float CurrentAge { get; }
        float ActualAge { get; set; }
        void Save();
    }
}