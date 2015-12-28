// Created 28.12.2015
// Modified by  28.12.2015 at 8:57

namespace Assets.Scripts.State.PlayerPrefs {
    internal interface IPlayerPrefs {
        void SaveString(string key, string s);
        string GetString(string key);
        void Save(string key, object obj);
        T Get<T>(string key);
    }
}