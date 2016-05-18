// Created 16.12.2015
// Modified by  21.12.2015 at 10:01

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
            var length = 0f;
            foreach (var prefab in prefabs) {
                var created = Instantiate(prefab) as GameObject;
                created.transform.SetParent(_container);
                var transf = created.GetComponent<RectTransform>();
                transf.anchoredPosition = new Vector3(length, 0);
                length += transf.sizeDelta.x;
            }
        }
    }
}