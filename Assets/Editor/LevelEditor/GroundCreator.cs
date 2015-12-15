// Created 15.12.2015
// Modified by Александр 15.12.2015 at 19:48

namespace Assets.Editor.LevelEditor {
    #region References

    using System.Collections.Generic;
    using UnityEditor;
    using UnityEngine;

    #endregion

    public class GroundCreator : EditorWindow {
        private Transform _container;
        private int _countToCreate = 0;

        [MenuItem("Window/Ground Creator")]
        public static void Init() {
            GetWindow<GroundCreator>();
        }

        private void OnGUI() {
            _countToCreate = EditorGUILayout.IntField("Создать, шт", _countToCreate);
            _container = EditorGUILayout.ObjectField("Контейнер", _container, typeof (Transform), true) as Transform;
            if (GUILayout.Button("Создать")) {
                var selection = Selection.GetFiltered(typeof (GameObject), SelectionMode.Assets);
                Create(selection);
            }
        }

        private void Create(IEnumerable<Object> prefabs) {
            foreach (var prefab in prefabs) {
                var created = Instantiate(prefab) as GameObject;
                created.transform.SetParent(_container);
            }
        }
    }
}