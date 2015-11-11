// Created 11.11.2015 
// Modified by Gorbach Alex 11.11.2015 at 15:19

#region References

using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using System.IO;
#endif
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityToolbag;

#endregion

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(SkinnedMeshRenderer))]
[RequireComponent(typeof(SortingLayerExposed))]
[ExecuteInEditMode()]
public class Skin2D : MonoBehaviour {
    public Sprite sprite;

    [HideInInspector]
    public Bone2DWeights boneWeights;

    private Material lineMaterial;
    private MeshFilter meshFilter;
    private SkinnedMeshRenderer skinnedMeshRenderer;
    private GameObject lastSelected = null;

    private MeshFilter MeshFilter {
        get {
            if (meshFilter == null) {
                meshFilter = GetComponent<MeshFilter>();
            }
            return meshFilter;
        }
    }

    private SkinnedMeshRenderer SkinnedMeshRenderer {
        get {
            if (skinnedMeshRenderer == null) {
                skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
            }
            return skinnedMeshRenderer;
        }
    }

    private Material LineMaterial {
        get {
            if (lineMaterial == null) {
                lineMaterial = new Material(Shader.Find("Lines/Colored Blended"));
                lineMaterial.hideFlags = HideFlags.HideAndDontSave;
                lineMaterial.shader.hideFlags = HideFlags.HideAndDontSave;
            }
            return lineMaterial;
        }
    }

#if UNITY_EDITOR
    [MenuItem("Sprites And Bones/Skin 2D")]
    public static void Create() {
        if (Selection.activeGameObject != null) {
            var o = Selection.activeGameObject;
            var skin = o.GetComponent<SkinnedMeshRenderer>();
            var spriteRenderer = o.GetComponent<SpriteRenderer>();
            if (skin == null && spriteRenderer != null) {
                var thisSprite = spriteRenderer.sprite;
                var spriteMesh = new SpriteMesh();
                spriteMesh.spriteRenderer = spriteRenderer;
                spriteMesh.CreateSpriteMesh();
                var spriteTexture = UnityEditor.Sprites.SpriteUtility.GetSpriteTexture(spriteRenderer.sprite, false);
                var spriteMaterial = new Material(spriteRenderer.sharedMaterial);
                spriteMaterial.CopyPropertiesFromMaterial(spriteRenderer.sharedMaterial);
                spriteMaterial.mainTexture = spriteTexture;
                var sortLayerName = spriteRenderer.sortingLayerName;
                var sortOrder = spriteRenderer.sortingOrder;
                DestroyImmediate(spriteRenderer);
                var skin2D = o.AddComponent<Skin2D>();
                skin2D.sprite = thisSprite;
                skin = o.GetComponent<SkinnedMeshRenderer>();
                var filter = o.GetComponent<MeshFilter>();
                skin.material = spriteMaterial;
                skin.sortingLayerName = sortLayerName;
                skin.sortingOrder = sortOrder;
                filter.mesh = (Mesh)Selection.activeObject;
                if (filter.sharedMesh != null && skin.sharedMesh == null) {
                    skin.sharedMesh = filter.sharedMesh;
                }
                // Recalculate the bone weights for the new mesh
                skin2D.RecalculateBoneWeights();
            }
            else {
                o = new GameObject("Skin2D");
                Undo.RegisterCreatedObjectUndo(o, "Create Skin2D");
                o.AddComponent<Skin2D>();
            }
        }
        else {
            var o = new GameObject("Skin2D");
            Undo.RegisterCreatedObjectUndo(o, "Create Skin2D");
            o.AddComponent<Skin2D>();
        }
    }
#endif

    // Use this for initialization
    private void Start() {
#if UNITY_EDITOR
        CalculateVertexColors();
#endif
        if (Application.isPlaying) {
            var oldMesh = GetComponent<SkinnedMeshRenderer>().sharedMesh;
            if (oldMesh != null) {
                var newMesh = (Mesh)Instantiate(oldMesh);
                GetComponent<SkinnedMeshRenderer>().sharedMesh = newMesh;
            }
        }
    }

    // Update is called once per frame
    private void Update() {
        if (MeshFilter.sharedMesh != null && GetComponent<SkinnedMeshRenderer>().sharedMesh == null) {
            GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshFilter.sharedMesh;
        }
        if (GetComponent<SortingLayerExposed>() == null) {
            gameObject.AddComponent<SortingLayerExposed>();
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos() {
        if (Application.isEditor && MeshFilter.sharedMesh != null) {
            CalculateVertexColors();
            GL.wireframe = true;
            LineMaterial.SetPass(0);
            Graphics.DrawMeshNow(MeshFilter.sharedMesh, transform.position, transform.rotation);
            GL.wireframe = false;
        }
    }

    public void CalculateBoneWeights(Bone[] bones) {
        CalculateBoneWeights(bones, false);
    }

    public void CalculateBoneWeights(Bone[] bones, bool weightToParent) {
        if (MeshFilter.sharedMesh == null) {
            Debug.Log("No Shared Mesh.");
            return;
        }
        var mesh = new Mesh();
        mesh.name = "Generated Mesh";
        mesh.vertices = MeshFilter.sharedMesh.vertices;
        mesh.triangles = MeshFilter.sharedMesh.triangles;
        mesh.normals = MeshFilter.sharedMesh.normals;
        mesh.uv = MeshFilter.sharedMesh.uv;
        mesh.uv2 = MeshFilter.sharedMesh.uv2;
        mesh.bounds = MeshFilter.sharedMesh.bounds;

        if (bones != null && mesh != null) {
            boneWeights = new Bone2DWeights();
            boneWeights.weights = new Bone2DWeight[] { };

            var index = 0;
            foreach (var bone in bones) {
                var i = 0;

                var boneActive = bone.gameObject.activeSelf;
                bone.gameObject.SetActive(true);
                foreach (var v in mesh.vertices) {
                    float influence;
                    if (!weightToParent || weightToParent && bone.transform != transform.parent) {
                        influence = bone.GetInfluence(v + transform.position);
                    }
                    else {
                        influence = 1.0f;
                    }

                    boneWeights.SetWeight(i, bone.name, index, influence);

                    i++;
                }

                index++;
                bone.gameObject.SetActive(boneActive);
            }

            var unitweights = boneWeights.GetUnityBoneWeights();
            mesh.boneWeights = unitweights;

            var bonesArr = bones.Select(b => b.transform).ToArray();
            var bindPoses = new Matrix4x4[bonesArr.Length];

            for (var i = 0; i < bonesArr.Length; i++) {
                bindPoses[i] = bonesArr[i].worldToLocalMatrix * transform.localToWorldMatrix;
            }

            mesh.bindposes = bindPoses;

            var skinRenderer = GetComponent<SkinnedMeshRenderer>();
            if (skinRenderer.sharedMesh != null && !AssetDatabase.Contains(skinRenderer.sharedMesh.GetInstanceID())) {
                DestroyImmediate(skinRenderer.sharedMesh);
            }
            skinRenderer.bones = bonesArr;
            skinRenderer.sharedMesh = mesh;
            EditorUtility.SetDirty(skinRenderer.gameObject);
            if (PrefabUtility.GetPrefabType(skinRenderer.gameObject) != PrefabType.None) {
                AssetDatabase.SaveAssets();
            }
        }
    }

    private void CalculateVertexColors() {
        var go = Selection.activeGameObject;

        if (go == lastSelected || MeshFilter.sharedMesh == null) {
            return;
        }

        lastSelected = go;

        var m = SkinnedMeshRenderer.sharedMesh;

        var colors = new Color[m.vertexCount];

        for (var i = 0; i < colors.Length; i++) {
            colors[i] = Color.black;
        }

        if (go != null) {
            var bone = go.GetComponent<Bone>();

            if (bone != null) {
                if (SkinnedMeshRenderer.bones.Any(b => b.gameObject.GetInstanceID() == bone.gameObject.GetInstanceID())) {
                    for (var i = 0; i < colors.Length; i++) {
                        float value = 0;

                        var bw = m.boneWeights[i];
                        if (bw.boneIndex0 == bone.index) {
                            value = bw.weight0;
                        }
                        else if (bw.boneIndex1 == bone.index) {
                            value = bw.weight1;
                        }
                        else if (bw.boneIndex2 == bone.index) {
                            value = bw.weight2;
                        }
                        else if (bw.boneIndex3 == bone.index) {
                            value = bw.weight3;
                        }

                        colors[i] = Util.HSBColor.ToColor(new Util.HSBColor(0.7f - value, 1.0f, 0.5f));
                    }
                }
            }
        }

        MeshFilter.sharedMesh.colors = colors;
    }

    public void SaveAsPrefab() {
        // Check if the Prefabs directory exists, if not, create it.
        var prefabDir = new DirectoryInfo("Assets/Prefabs");
        if (Directory.Exists(prefabDir.FullName) == false) {
            Directory.CreateDirectory(prefabDir.FullName);
        }

        var skeletons = transform.root.gameObject.GetComponentsInChildren<Skeleton>(true);
        Skeleton skeleton = null;
        foreach (var s in skeletons) {
            if (transform.IsChildOf(s.transform)) {
                skeleton = s;
            }
        }

        var prefabSkelDir = new DirectoryInfo("Assets/Prefabs/" + skeleton.gameObject.name);
        if (Directory.Exists(prefabSkelDir.FullName) == false) {
            Directory.CreateDirectory(prefabSkelDir.FullName);
        }

        var path = "Assets/Prefabs/" + skeleton.gameObject.name + "/" + gameObject.name + ".prefab";

        var obj = PrefabUtility.CreateEmptyPrefab(path);

        AssetDatabase.AddObjectToAsset(GetComponent<SkinnedMeshRenderer>().sharedMesh, obj);

        PrefabUtility.ReplacePrefab(gameObject, obj, ReplacePrefabOptions.ConnectToPrefab);
    }

    public void RecalculateBoneWeights() {
        var skeletons = transform.root.gameObject.GetComponentsInChildren<Skeleton>(true);
        Skeleton skeleton = null;
        foreach (var s in skeletons) {
            if (transform.IsChildOf(s.transform)) {
                skeleton = s;
            }
        }
        if (skeleton != null) {
            skeleton.CalculateWeights(true);
            // Debug.Log("Calculated weights for " + gameObject.name);
        }
    }

    public void ResetControlPointPositions() {
        var controlPoints = GetComponentsInChildren<ControlPoint>();
        if (controlPoints != null) {
            foreach (var controlPoint in controlPoints) {
                controlPoint.ResetPosition();
                // Debug.Log("Reset Control Point Positions for " + gameObject.name);
            }
        }
    }
#endif
}