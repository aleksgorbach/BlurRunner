using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor
{
    public class Renamer : EditorWindow
    {
        [MenuItem("Tools/Renamer")]
        public static void Init()
        {
            GetWindow<Renamer>().titleContent.text = "Renamer";
        }

        private Vector2 _scrollPos;

        private string _namePrefix = "";
        private IEnumerable<string> _selected;
        
        private int _index = 0;

        private void OnGUI()
        {
            _scrollPos = GUILayout.BeginScrollView(_scrollPos);
            {
                _namePrefix = EditorGUILayout.TextField("Prefix", _namePrefix);
                if (GUILayout.Button("Get selection"))
                {
                    _selected = Selection.GetFiltered(typeof(Object), SelectionMode.Assets).Select(x => AssetDatabase.GetAssetPath(x));
                }
                if (_selected != null)
                {
                    if (GUILayout.Button("Rename"))
                    {
                        foreach (var obj in _selected)
                        {
                            AssetDatabase.RenameAsset(obj, _namePrefix + _index++);
                        }
                    }

                    foreach (var obj in _selected)
                    {
                        GUILayout.Label(obj);
                    }
                }
            }
            GUILayout.EndScrollView();
        }
    }
}