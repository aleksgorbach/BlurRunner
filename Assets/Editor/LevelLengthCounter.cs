namespace Assets.Editor {
    using System;
    using UnityEditor;
    using UnityEngine;

    public class LevelLengthCounter {
        private const float HERO_VELOCITY = 250f;

        [MenuItem("Tools/Посчитать длину уровня")]
        public static void GetLevelLength() {
            var levelEnd = GameObject.Find("LevelEnd");
            if (levelEnd == null) {
                return;
            }
            var time = levelEnd.transform.position.x/HERO_VELOCITY;
            var span = TimeSpan.FromSeconds(time);
            EditorUtility.DisplayDialog("Длина уровня",
                string.Format("Примерная длина уровня: {0:00}:{1:00}", span.Minutes, span.Seconds), "OK");
        }
    }
}