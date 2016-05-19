namespace Assets.Editor.LevelEditor {
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Scripts.State.Levels.Data;
    using Scripts.State.Levels.Loaders;
    using UnityEditor;
    using UnityEngine;

    public class LevelEditor : EditorWindow {
        public const string LEVELS_PATH = "Levels/levels";

        [MenuItem("SCURRY/Level Editor")]
        public static void Init() {
            GetWindow(typeof (LevelEditor)).titleContent.text = "Level Editor";
        }

        // Saved data
        private List<LevelData> _levels;

        private Vector2 _scrollPos;

        private void OnGUI() {
            if (_levels == null) {
                Load();
            }
            _scrollPos = GUILayout.BeginScrollView(_scrollPos);
            {
                GUILayout.BeginVertical();
                {
                    if (GUILayout.Button("Save")) {
                        Save();
                    }
                    foreach (var level in _levels) {
                        GUILayout.BeginHorizontal();
                        {
                            level.LevelNumber = EditorGUILayout.IntSlider("Level", level.LevelNumber, 0, 100,
                                GUILayout.Width(300));
                            level.HeroAge = EditorGUILayout.IntSlider("Age", level.HeroAge, 1, 101, GUILayout.Width(300));
                            if (GUILayout.Button("Background: " + level.Background, GUILayout.Width(200))) {
                                var path = Path.GetFileName(EditorUtility.OpenFilePanel("",
                                    "Assets/Resources/Levels/Backgrounds",
                                    "png"));
                                if (path != null) {
                                    level.Background = path.Replace(".png", "");
                                }
                            }
                            if (GUILayout.Button("Hero: " + level.Hero, GUILayout.Width(200))) {
                                var path = Path.GetFileName(EditorUtility.OpenFilePanel("",
                                    "Assets/Resources/Levels/Heroes",
                                    "prefab"));
                                if (path != null) {
                                    level.Hero = path.Replace(".prefab", "");
                                }
                            }
                            if (GUILayout.Button("Scene: " + level.Scene, GUILayout.Width(200))) {
                                var path = Path.GetFileName(EditorUtility.OpenFilePanel("",
                                    "Assets/StaticAssets/4 - Game/Levels",
                                    "unity"));
                                if (path != null) {
                                    level.Scene = path.Replace(".unity", "");
                                }
                            }
                        }
                        GUILayout.EndHorizontal();
                    }
                }
                if (GUILayout.Button("+")) {
                    var maxLevel = _levels.Max(x => x.LevelNumber);
                    _levels.Add(new LevelData {
                        Background = "7",
                        Hero = "Hero_new",
                        LevelNumber = maxLevel + 1,
                        HeroAge = maxLevel + 2,
                        Scene = "Level_" + (maxLevel + 1)
                    });
                }
                GUILayout.EndVertical();
            }
            GUILayout.EndScrollView();
        }

        private void OnDestroy() {
            if (EditorUtility.DisplayDialog("Saving", "Save?", "Yes", "No")) {
                Save();
            }
        }

        private void Load() {
            _levels = new List<LevelData>();
            var lvls = Resources.Load<TextAsset>(LEVELS_PATH);
            if (lvls == null) {
                return;
            }
            _levels = new LevelsParser().Parse(lvls.text).ToList();
        }

        private void Save() {
            var json = new JSONObject(JSONObject.Type.ARRAY);
            foreach (var level in _levels) {
                var entry = new JSONObject();
                entry.AddField("background", level.Background);
                entry.AddField("level", level.LevelNumber);
                entry.AddField("age", level.HeroAge);
                entry.AddField("hero", level.Hero);
                entry.AddField("scene", level.Scene ?? "Level_" + level.LevelNumber);
                json.Add(entry);
            }
            using (
                var writer =
                    new StreamWriter(new FileStream(Application.dataPath + "/Resources/" + LEVELS_PATH + ".json",
                        FileMode.Create))) {
                writer.Write(json.ToString());
            }
            AssetDatabase.Refresh();
        }
    }
}