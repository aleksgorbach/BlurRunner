namespace Assets.Scripts {
    using System.Collections.Generic;
    using System.Linq;
    using Engine;
    using UnityEngine;

    [RequireComponent(typeof (MeshFilter))]
    [RequireComponent(typeof (MeshRenderer))]
    internal class GroundFiller : MonoBehaviourBase {
        [SerializeField]
        private Material _material;

        protected override void Awake() {
            base.Awake();
            Fill();
        }

        private void Fill() {
            var colliders =
                GameObject.Find("Ground")
                    .transform.Cast<Transform>()
                    .Select(obj => obj.GetComponent<EdgeCollider2D>())
                    .Where(col => col != null)
                    .ToList();
            var points = new List<Vector2>();
            for (var i = 0; i < colliders.Count; i++) {
                points.AddRange(colliders[i].points);
            }
            points = points.OrderBy(x => x.x).ToList();
            points.Insert(0, points.First() + new Vector2(-1, -15000));
            points.Add(points.Last() + new Vector2(1, -15000));

            var mf = GetComponent<MeshFilter>();
            var mesh = new Mesh();

            //var points = new[]
            //{new Vector2(0, 0), new Vector2(0, 500), new Vector2(600, 200), new Vector2(900, 0)};

            var vertices = new Vector3[points.Count];
            for (var j = 0; j < points.Count; j++) {
                var actual = points[j];
                vertices[j] = new Vector3(actual.x, actual.y, 0);
            }
            var triangles = Triangulator.Triangulate(points);

            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mf.mesh = mesh;
            GetComponent<MeshRenderer>().material = _material;
        }
    }
}