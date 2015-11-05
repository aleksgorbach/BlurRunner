// Created 04.11.2015 
// Modified by Gorbach Alex 05.11.2015 at 9:57

#if UNITY_EDITOR

#region References

using System.IO;
using UnityEditor;
using UnityEngine;

#endregion

public static class CustomAssetUtility {
    public static void CreateAsset<T>() where T : ScriptableObject {
        var asset = ScriptableObject.CreateInstance<T>();

        var path = AssetDatabase.GetAssetPath(Selection.activeObject);
        if (path == "") {
            path = "Assets";
        }
        else if (Path.GetExtension(path) != "") {
            path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
        }

        var assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/" + typeof(T).Name + ".asset");

        AssetDatabase.CreateAsset(asset, assetPathAndName);

        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }
}
#endif