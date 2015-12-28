// Created 28.12.2015
// Modified by  28.12.2015 at 10:56

namespace Assets.Scripts.State.PlayerPrefs {
    #region References

    using UnityEngine;

    #endregion

    internal class PlayerPrefs : IPlayerPrefs {
        public void SaveString(string key, string s) {
            UnityEngine.PlayerPrefs.SetString(key, s);
            UnityEngine.PlayerPrefs.Save();
        }

        public string GetString(string key) {
            return UnityEngine.PlayerPrefs.GetString(key);
        }

        public bool GetBool(string key) {
            return UnityEngine.PlayerPrefs.GetInt(key, 0) == 1;
        }

        public void SaveBool(string key, bool value) {
            UnityEngine.PlayerPrefs.SetInt(key, value ? 1 : 0);
            UnityEngine.PlayerPrefs.Save();
        }

        public void Save(string key, object obj) {
            var json = JsonUtility.ToJson(obj);
            UnityEngine.PlayerPrefs.SetString(key, json);
            UnityEngine.PlayerPrefs.Save();
        }

        public T Get<T>(string key) {
            var json = UnityEngine.PlayerPrefs.GetString(key);
            if (string.IsNullOrEmpty(json)) {
                throw new KeyNotFoundException(key);
            }
            return JsonUtility.FromJson<T>(json);
        }
    }
}