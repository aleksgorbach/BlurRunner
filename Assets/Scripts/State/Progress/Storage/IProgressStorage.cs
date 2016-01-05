namespace Assets.Scripts.State.Progress.Storage {
    #region References

    using System;

    #endregion

    internal delegate void ProgressChangeDelegate(float delta);

    internal interface IProgressStorage {
        int CurrentAge { get; set; }
        float ActualAge { get; set; }
        event EventHandler<ProgressChangedArgs> ActualAgeChanged;
        event EventHandler<ProgressChangedArgs> CurrentAgeChanged;
    }
}