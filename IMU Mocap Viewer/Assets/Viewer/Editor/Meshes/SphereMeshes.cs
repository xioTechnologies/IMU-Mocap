using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Viewer.Runtime;

namespace Viewer.Editor.Meshes
{
    static class Sphere
    {
        public static void GenerateMesh(int subdivisions, string path)
        {
            (Mesh mesh, bool exists) = MeshData.CreateOrLoadMesh(path, $"Stretch Icosphere Subdivisions {subdivisions}");

            var data = new MeshData();

            float radius = 0.5f;

            foreach (var thickness in InitialThickness) data.AddVertex(Vector3.zero, thickness * radius, Vector2.zero);

            List<int[]> faces = new List<int[]>(InitialFaces);

            for (int i = 0; i < subdivisions; i++)
            {
                var newFaces = new List<int[]>();
                var midPointCache = new Dictionary<long, int>();

                foreach (int[] tri in faces)
                {
                    int a = tri[0];
                    int b = tri[1];
                    int c = tri[2];

                    int ab = Split(a, b, data, midPointCache, radius);
                    int bc = Split(b, c, data, midPointCache, radius);
                    int ca = Split(c, a, data, midPointCache, radius);

                    newFaces.Add(new[] { a, ab, ca });
                    newFaces.Add(new[] { b, bc, ab });
                    newFaces.Add(new[] { c, ca, bc });
                    newFaces.Add(new[] { ab, bc, ca });
                }

                faces = newFaces;
            }

            foreach (int[] tri in faces) data.AddTriangle(tri[0], tri[1], tri[2]);

            MeshData.Merge(mesh, data);

            mesh.bounds = new Bounds(Vector3.zero, Vector3.one);

            MeshData.SaveMesh(exists, mesh, path);
        }

        static int Split(int indexA, int indexB, MeshData data, Dictionary<long, int> midPointCache, float radius)
        {
            int smallerIndex = Mathf.Min(indexA, indexB);
            int greaterIndex = Mathf.Max(indexA, indexB);

            long key = ((long)smallerIndex << 32) + greaterIndex;

            if (midPointCache.TryGetValue(key, out int ret)) return ret;

            var pointA = new Vector3(data.Thickness[indexA].x, data.Thickness[indexA].y, data.Thickness[indexA].z);
            var pointB = new Vector3(data.Thickness[indexB].x, data.Thickness[indexB].y, data.Thickness[indexB].z);

            Vector3 middle = ((pointA + pointB) / 2.0f).normalized * radius;

            int newIndex = data.AddVertex(Vector3.zero, new Vector4(middle.x, middle.y, middle.z, 0f), Vector2.zero);

            midPointCache.Add(key, newIndex);

            return newIndex;
        }

        private static readonly float GoldenRatio = (1.0f + Mathf.Sqrt(5.0f)) / 2.0f;

        private static readonly Vector4[] InitialThickness = new Vector3[]
        {
            new(-1, GoldenRatio, 0),
            new(1, GoldenRatio, 0),
            new(-1, -GoldenRatio, 0),
            new(1, -GoldenRatio, 0),

            new(0, -1, GoldenRatio),
            new(0, 1, GoldenRatio),
            new(0, -1, -GoldenRatio),
            new(0, 1, -GoldenRatio),

            new(GoldenRatio, 0, -1),
            new(GoldenRatio, 0, 1),
            new(-GoldenRatio, 0, -1),
            new(-GoldenRatio, 0, 1)
        }.Select(v => v.normalized._xyz0()).ToArray();

        private static readonly int[][] InitialFaces =
        {
            new[] { 0, 11, 5 },
            new[] { 0, 5, 1 },
            new[] { 0, 1, 7 },
            new[] { 0, 7, 10 },
            new[] { 0, 10, 11 },

            new[] { 1, 5, 9 },
            new[] { 5, 11, 4 },
            new[] { 11, 10, 2 },
            new[] { 10, 7, 6 },
            new[] { 7, 1, 8 },

            new[] { 3, 9, 4 },
            new[] { 3, 4, 2 },
            new[] { 3, 2, 6 },
            new[] { 3, 6, 8 },
            new[] { 3, 8, 9 },

            new[] { 4, 9, 5 },
            new[] { 2, 4, 11 },
            new[] { 6, 2, 10 },
            new[] { 8, 6, 7 },
            new[] { 9, 8, 1 }
        };
    }
}