// Created 28.12.2015
// Modified by  28.12.2015 at 9:01

namespace Assets.Scripts.State.PlayerPrefs {
    #region References

    using System;

    #endregion

    internal class KeyNotFoundException : ArgumentException {
        public KeyNotFoundException(string key) : base("Given key is not presented in player prefs: " + key) {
        }
    }
}