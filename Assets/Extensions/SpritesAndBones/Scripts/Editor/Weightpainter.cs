// Created 11.11.2015 
// Modified by Gorbach Alex 11.11.2015 at 16:43

#region References

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

#endregion

public enum PaintingMode {
    Add,
    Subtract
}

public class Weightpainter : EditorWindow {
    public SkinnedMeshRenderer skin;
    private bool isPainting = false;
    private bool isDrawing = false;
    private float brushSize = 0.5f;
    private float weight = 1.0f;
    private float colorTransparency = 1.0f;
    private PaintingMode mode = PaintingMode.Add;
    private int boneIndex = 0;

    [MenuItem("Sprites And Bones/Weight painting")]
    protected static void ShowWeightpainterWindow() {
        var wnd = GetWindow<Weightpainter>();
        wnd.title = "Weight painting";

        if (Selection.activeGameObject != null) {
            var skin = Selection.activeGameObject.GetComponent<SkinnedMeshRenderer>();
            if (skin != null) {
                wnd.skin = skin;
            }
        }

        SceneView.onSceneGUIDelegate += wnd.OnSceneGUI;
        wnd.Show();
    }

    public void OnDestroy() {
        SceneView.onSceneGUIDelegate -= OnSceneGUI;
    }

    public void OnGUI() {
        skin = (SkinnedMeshRenderer)EditorGUILayout.ObjectField("Skin", skin, typeof(SkinnedMeshRenderer), true);

        if (skin != null && skin.bones.Length > 0) {
            GUI.color = (isPainting) ? Color.green : Color.white;

            if (GUILayout.Button("Paint")) {
                isPainting = !isPainting;
                if (isPainting) {
                    Selection.objects = new GameObject[] { skin.gameObject };
                }
                SceneView.currentDrawingSceneView.Repaint();
            }

            GUI.color = Color.white;

            brushSize = EditorGUILayout.FloatField("Brush size", brushSize * 2) / 2;
            weight = Mathf.Clamp(EditorGUILayout.FloatField("Weight", weight), 0, 1);
            mode = (PaintingMode)EditorGUILayout.EnumPopup("Mode", mode);

            var bones = skin.bones.Select(b => b.gameObject.name).ToArray();
            boneIndex = EditorGUILayout.Popup("Bone", boneIndex, bones);
            colorTransparency = Mathf.Clamp(EditorGUILayout.FloatField("Color Transparency", colorTransparency), 0, 1);
        }
        else {
            EditorGUILayout.HelpBox(
                "SkinnedMeshRenderer not assigned to any bones, Recalculate Bone Weights.",
                MessageType.Error);
            SceneView.currentDrawingSceneView.Repaint();
        }
    }

    public void OnSceneGUI(SceneView sceneView) {
        if (skin != null && isPainting) {
            HandleUtility.AddDefaultControl(GUIUtility.GetControlID(FocusType.Passive));

            var m = skin.sharedMesh.Clone();
            m.colors = CalculateVertexColors(skin.bones, m, skin.bones[boneIndex].GetComponent<Bone>());

            var weights = m.boneWeights.ToList();

            var current = Event.current;

            Graphics.DrawMeshNow(m, skin.transform.position, skin.transform.rotation);

            var bn = skin.bones[boneIndex].GetComponent<Bone>();

            foreach (var b in skin.GetComponentsInChildren<Bone>()) {
                if (bn == b) {
                    Handles.color = Color.yellow;
                }
                else {
                    Handles.color = Color.gray;
                }
                Handles.DrawLine(b.transform.position, b.Head);
            }

            Handles.color = Color.red;
            var mpos = HandleUtility.GUIPointToWorldRay(current.mousePosition).origin;
            mpos = new Vector3(mpos.x, mpos.y);
            Handles.DrawWireDisc(mpos, Vector3.forward, brushSize);

            if (isPainting) {
                if (current.type == EventType.scrollWheel && current.modifiers == EventModifiers.Control) {
                    brushSize = Mathf.Clamp(
                        brushSize + (float)System.Math.Round(current.delta.y / 30, 2),
                        0,
                        float.MaxValue);
                    Repaint();
                    current.Use();
                }
                else if (current.type == EventType.mouseDown && current.button == 0) {
                    isDrawing = true;
                }
                else if (current.type == EventType.mouseUp && current.button == 0) {
                    isDrawing = false;
                }
                else if (current.type == EventType.mouseDrag && isDrawing && current.button == 0) {
                    var w = weight * ((mode == PaintingMode.Subtract) ? -1 : 1);

                    for (var i = 0; i < m.vertices.Length; i++) {
                        var v = m.vertices[i];
                        var d = (v - skin.gameObject.transform.InverseTransformPoint(mpos)).magnitude;

                        if (d <= brushSize) {
                            var bw = weights[i];
                            var vw = bw.GetWeight(boneIndex);
                            vw = Mathf.Clamp(vw + (1 - d / brushSize) * w, 0, 1);
                            bw = bw.SetWeight(boneIndex, vw);
                            weights[i] = bw.Clone();
                        }
                    }

                    skin.sharedMesh.boneWeights = weights.ToArray();
                    EditorUtility.SetDirty(skin.gameObject);
                    if (PrefabUtility.GetPrefabType(skin.gameObject) != PrefabType.None) {
                        AssetDatabase.SaveAssets();
                    }
                }
            }

            sceneView.Repaint();
        }
    }

    private Color[] CalculateVertexColors(Transform[] bones, Mesh m, Bone bone) {
        var colors = new Color[m.vertexCount];

        for (var i = 0; i < colors.Length; i++) {
            colors[i] = Color.black;
        }

        if (bones.Any(b => b.gameObject.GetInstanceID() == bone.gameObject.GetInstanceID())) {
            for (var i = 0; i < colors.Length; i++) {
                float value = 0;

                var bw = m.boneWeights[i];
                if (bw.boneIndex0 == boneIndex) {
                    value = bw.weight0;
                }
                else if (bw.boneIndex1 == boneIndex) {
                    value = bw.weight1;
                }
                else if (bw.boneIndex2 == boneIndex) {
                    value = bw.weight2;
                }
                else if (bw.boneIndex3 == boneIndex) {
                    value = bw.weight3;
                }

                var hsbColor = new Util.HSBColor(0.7f - value, 1.0f, 0.5f);
                hsbColor.a = colorTransparency;
                colors[i] = Util.HSBColor.ToColor(hsbColor);
            }
        }

        return colors;
    }
}