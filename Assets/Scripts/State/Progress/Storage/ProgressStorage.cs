// Created 14.01.2016
// Modified by  19.01.2016 at 15:59

namespace Assets.Scripts.State.Progress.Storage {
    #region References

    using Engine;
    using Gameplay;
    using Gameplay.Consts;
    using PlayerPrefs;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class ProgressStorage : IProgressStorage, IGameStartedHandler, IGameLoopUpdatable {
        [Inject]
        private IPlayerPrefs _prefs;

        private float _levelStartTime;
        private float _ageAtLevelStart;

        [PostInject]
        private void PostInject() {
            Load();
        }

        #region Interface

        public float CurrentAge { get; private set; }

        public float ActualAge { get; set; }

        public void Save() {
            var state = new State {ActualAge = ActualAge, CurrentAge = CurrentAge};
            _prefs.Save(Identifiers.Progress.Storage, state);
        }

        public void OnGameStarted(IGame game) {
            _levelStartTime = Time.timeSinceLevelLoad;
            _ageAtLevelStart = CurrentAge;
        }

        public void Update(IGame game) {
            var timePassed = Time.timeSinceLevelLoad - _levelStartTime;
            CurrentAge = _ageAtLevelStart + timePassed/game.PerfectLevelTime;
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
            public float CurrentAge;
            public float ActualAge;
        }
    }
}