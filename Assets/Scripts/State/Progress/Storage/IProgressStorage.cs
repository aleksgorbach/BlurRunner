// Created 14.01.2016
// Modified by  20.01.2016 at 13:06

namespace Assets.Scripts.State.Progress.Storage {

    #region References

    #endregion

    internal interface IProgressStorage {
        /// <summary>
        /// Идеальный возраст, идущий независимо
        /// </summary>
        float CurrentAge { get; }

        /// <summary>
        /// Фактический возраст (прогресс), зависит от успешности прохождения уровня
        /// </summary>
        float ActualAge { get; }
    }
}