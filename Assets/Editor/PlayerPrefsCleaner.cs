// Created 20.01.2016
// Modified by  20.01.2016 at 13:09

namespace Assets.Editor {
    #region References

    using UnityEditor;
    using UnityEngine;

    #endregion

    public static class PlayerPrefsCleaner {
        [MenuItem("Tools/Clear PlayerPrefs")]
        public static void Clear() {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
    }
}