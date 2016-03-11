namespace Assets.Scripts.GeneratingHelpers {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Mr1;
    using UnityEngine;

    [ExecuteInEditMode]
    [RequireComponent(typeof (WaypointManager))]
    public class HillsGenerator : MonoBehaviour {
        [SerializeField]
        [Range(1, 50)]
        private int _precision = 5;

        [SerializeField]
        private Material _material;

        private WaypointManager _manager;
        private List<MeshCollider> _colliders;

        private void Awake() {
            _manager = GetComponent<WaypointManager>();
            _colliders = GetComponentsInChildren<MeshCollider>().ToList();
        }

        public void Generate() {
            foreach (var coll in _colliders.Where(x => x != null)) {
                DestroyImmediate(coll.gameObject);
            }
            _colliders.Clear();
            if (_manager.pathList.Count < 1) {
                return;
            }
            var path = _manager.pathList[0];
            var pointsCount = path.points.Count;
            var data = new BezierPoint[pointsCount];
            for (var i = 0; i < pointsCount; i++) {
                data[i] = new BezierPoint(path.points[i], path.firstHandles[i], path.secondHandles[i]);
            }
            _colliders = GeneratePoints(data).ToList();
        }


        private IEnumerable<MeshCollider> GeneratePoints(BezierPoint[] source) {
            Array.Sort(source, (x, y) => x.Point.x.CompareTo(y.Point.x));
            for (var i = 0; i < source.Length - 1; i++) {
                var first = source[i];
                var second = source[i + 1];
                var p0 = new Vector2(0, first.Point.y);
                var p1 = p0 + first.SecondRuler;
                var p3 = new Vector2(second.Point.x - first.Point.x, second.Point.y);
                var p2 = p3 + second.FirstRuler;
                var step = 1f/_precision;
                var points = new List<Vector2>();
                var t = 0f;
                while (t - 1 <= 0.01f) {
                    var vertice = Cube(1 - t)*p0 + 3*t*Sqr(1 - t)*p1 + 3*Sqr(t)*(1 - t)*p2 + Cube(t)*p3;
                    points.Add(vertice);
                    t += step;
                }
                points.Add(new Vector2(p3.x, 0));
                points.Add(Vector2.zero);
                var meshCol = GenerateMesh(points);
                meshCol.transform.SetParent(transform);
                meshCol.transform.localPosition = new Vector2(first.Point.x, 0);
                meshCol.gameObject.name = "Ground_" + i;
                yield return meshCol;
                //var colObj = new GameObject("Ground_" + i);
                //colObj.transform.SetParent(transform);
                //colObj.transform.localPosition = new Vector2(first.Point.x, 0);
                //var coll = colObj.AddComponent<PolygonCollider2D>();
                //coll.SetPath(0, points.ToArray());
                //yield return coll;
            }
        }

        private MeshCollider GenerateMesh(IList<Vector2> points) {
            var pointCount = points.Count;

            var obj = new GameObject();
            var mf = obj.AddComponent<MeshFilter>();
            var mesh = new Mesh();
            var vertices = new Vector3[pointCount];
            for (var j = 0; j < pointCount; j++) {
                var actual = points[j];
                vertices[j] = new Vector3(actual.x, actual.y, 0);
            }
            var triangles = Triangulator.Triangulate(points);
            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mf.mesh = mesh;
            var mr = obj.AddComponent<MeshRenderer>();
            mr.sharedMaterial = _material;
            var col = obj.AddComponent<MeshCollider>();
            col.sharedMesh = mesh;
            return col;
        }

        private static float Cube(float value) {
            return value*value*value;
        }

        private static float Sqr(float value) {
            return value*value;
        }

        private class BezierPoint {
            public Vector2 Point;
            public Vector2 FirstRuler;
            public Vector2 SecondRuler;

            public BezierPoint(Vector2 point, Vector2 firstRuler, Vector2 secondRuler) {
                Point = point;
                FirstRuler = firstRuler;
                SecondRuler = secondRuler;
            }
        }
    }
}