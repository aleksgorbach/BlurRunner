// Created 11.11.2015 
// Modified by Gorbach Alex 11.11.2015 at 15:20

#region References

using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using System.IO;
#endif
using System;
using System.Collections;
using System.Linq;

#endregion

public class SpriteMesh {
#if UNITY_EDITOR

    public SpriteRenderer spriteRenderer;

    public void CreateSpriteMesh() {
        if (spriteRenderer != null && spriteRenderer.sprite != null) {
            // Unparent the skin temporarily before adding the mesh
            var spriteRendererParent = spriteRenderer.transform.parent;
            spriteRenderer.transform.parent = null;

            // Reset the rotation before creating the mesh so the UV's will align properly
            var localRotation = spriteRenderer.transform.localRotation;
            spriteRenderer.transform.localRotation = Quaternion.identity;

            // Reset the scale before creating the mesh so the UV's will align properly
            var localScale = spriteRenderer.transform.localScale;
            spriteRenderer.transform.localScale = Vector3.one;

            var vertices2D = UnityEditor.Sprites.SpriteUtility.GetSpriteMesh(spriteRenderer.sprite, false);
            var indices =
                UnityEditor.Sprites.SpriteUtility.GetSpriteIndices(spriteRenderer.sprite, false)
                    .Select(element => (int)element)
                    .ToArray();

            // Create the Vector3 vertices
            var vertices = new Vector3[vertices2D.Length];
            for (var i = 0; i < vertices.Length; i++) {
                vertices[i] = new Vector3(vertices2D[i].x, vertices2D[i].y, 0);
            }

            var mesh = new Mesh();
            mesh.vertices = vertices;
            mesh.triangles = indices;
            Vector2[] uvs = UnityEditor.Sprites.SpriteUtility.GetSpriteUVs(spriteRenderer.sprite, false);
            mesh.uv = uvs;
            mesh.RecalculateNormals();
            mesh.RecalculateBounds();

            // Check if the Meshes directory exists, if not, create it.
            var meshDir = new DirectoryInfo("Assets/Meshes");
            if (Directory.Exists(meshDir.FullName) == false) {
                Directory.CreateDirectory(meshDir.FullName);
            }
            ScriptableObjectUtility.CreateAsset(mesh, "Meshes/" + spriteRenderer.gameObject.name + ".Mesh");

            // Reset the rotations of the object
            spriteRenderer.transform.localRotation = localRotation;
            spriteRenderer.transform.localScale = localScale;
            spriteRenderer.transform.parent = spriteRendererParent;
        }
    }
#endif
}