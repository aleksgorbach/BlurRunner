namespace Assets.Scripts.State.Progress.Storage {
    #region References

    using System;

    #endregion

    internal interface IProgressStorage {
        int CurrentAge { get; set; }
        float ActualAge { get; set; }
        void Save();
    }
}