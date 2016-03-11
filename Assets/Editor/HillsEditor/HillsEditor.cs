namespace Assets.Editor.HillsEditor {
    using Scripts.GeneratingHelpers;
    using UnityEditor;
    using UnityEngine;

    [CustomEditor(typeof (HillsGenerator))]
    class HillsEditor : Editor {
        private HillsGenerator _generator;
        private int _precision;

        private void OnEnable() {
            _generator = target as HillsGenerator;
        }

        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
            EditorGUILayout.BeginVertical();
            {
                if (GUILayout.Button("Generate")) {
                    _generator.Generate();
                }
            }
            EditorGUILayout.EndVertical();
        }
    }
}