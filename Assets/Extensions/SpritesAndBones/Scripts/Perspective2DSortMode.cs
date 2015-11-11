// Created 11.11.2015 
// Modified by Gorbach Alex 11.11.2015 at 15:18

#region References

using UnityEngine;

#endregion

[RequireComponent(typeof(Camera))]
[ExecuteInEditMode()]
public class Perspective2DSortMode : MonoBehaviour {
    private void Awake() {
        GetComponent<Camera>().transparencySortMode = TransparencySortMode.Orthographic;
    }
}