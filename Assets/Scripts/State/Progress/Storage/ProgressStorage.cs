namespace Assets.Scripts.State.Progress.Storage {
    #region References

    using Gameplay.Consts;
    using PlayerPrefs;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class ProgressStorage : IProgressStorage {
        [Inject]
        private IPlayerPrefs _prefs;

        [PostInject]
        private void PostInject() {
            Load();
        }

        #region Interface

        public int CurrentAge { get; set; }

        public float ActualAge { get; set; }

        public void Save() {
            var state = new State {ActualAge = ActualAge, CurrentAge = CurrentAge};
            _prefs.Save(Identifiers.Progress.Storage, state);
        }

        #endregion

        private void Load() {
            try {
                var state = _prefs.Get<State>(Identifiers.Progress.Storage);
                CurrentAge = state.CurrentAge;
                ActualAge = state.ActualAge;
                Debug.Log("Loaded actual age:" + ActualAge);
            }
            catch (KeyNotFoundException e) {
                Debug.Log(e);
            }
        }


        public class State {
            public int CurrentAge;
            public float ActualAge;
        }
    }
}