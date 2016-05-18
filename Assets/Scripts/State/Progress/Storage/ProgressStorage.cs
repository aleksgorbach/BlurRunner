// Created 14.01.2016
// Modified by  20.01.2016 at 13:56

namespace Assets.Scripts.State.Progress.Storage {
    #region References

    using System;
    using Engine;
    using Gameplay;
    using Gameplay.Consts;
    using PlayerPrefs;
    using UnityEngine;

    #endregion

    internal class ProgressStorage : IProgressStorage, IGameStartedHandler, IGameLoopUpdatable, IDisposable {
        private readonly IPlayerPrefs _prefs;

        private IGame _game;

        public ProgressStorage(IPlayerPrefs prefs) {
            _prefs = prefs;
            Load();
        }

        #region Interface

        public float CurrentAge { get; private set; }

        public float ActualAge { get; private set; }

        public void OnGameStarted(IGame game) {
            _game = game;
        }

        public void Update(IGame game) {
            CurrentAge += Time.deltaTime*_game.NominalHeroSpeed/_game.LevelLength;
            ActualAge += Time.deltaTime*_game.CurrentHeroSpeed.x/_game.LevelLength;
        }

        public void Dispose() {
            Save();
        }

        #endregion

        private void Load() {
            try {
                var state = _prefs.Get<State>(Identifiers.Progress.Storage);
                CurrentAge = state.CurrentAge;
                ActualAge = state.ActualAge;
                Debug.Log("Loaded current age:" + CurrentAge);
                Debug.Log("Loaded actual age:" + ActualAge);
            }
            catch (KeyNotFoundException) {
            }
        }

        private void Save() {
            var state = new State {ActualAge = ActualAge, CurrentAge = CurrentAge};
            _prefs.Save(Identifiers.Progress.Storage, state);
        }


        public class State {
            public float CurrentAge;
            public float ActualAge;
        }
    }
}