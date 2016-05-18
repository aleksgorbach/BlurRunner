// Created 28.12.2015
// Modified by  28.12.2015 at 10:56

namespace Assets.Scripts.State.PlayerPrefs {
    internal interface IPlayerPrefs {
        void SaveString(string key, string s);
        string GetString(string key);
        bool GetBool(string key);
        void SaveBool(string key, bool value);
        void Save(string key, object obj);
        T Get<T>(string key);
    }
}