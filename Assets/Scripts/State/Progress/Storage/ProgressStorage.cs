namespace Assets.Scripts.State.Progress.Storage {
    #region References

    using System;
    using Engine.Extensions;

    #endregion

    internal class ProgressStorage : IProgressStorage {
        private const float TOLERANCE = 0.01f;

        private float _actualAge;
        private int _currentAge;

        #region Interface

        public int CurrentAge {
            get { return _currentAge; }
            set {
                var prev = _currentAge;
                _currentAge = value;
                CurrentAgeChanged.SafeInvoke(this, new ProgressChangedArgs(_currentAge - prev));
            }
        }

        public float ActualAge {
            get { return _actualAge; }
            set {
                var prev = _actualAge;
                _actualAge = value;
                ActualAgeChanged.SafeInvoke(this, new ProgressChangedArgs(_actualAge - prev));
            }
        }

        public event EventHandler<ProgressChangedArgs> ActualAgeChanged;
        public event EventHandler<ProgressChangedArgs> CurrentAgeChanged;

        #endregion
    }
}