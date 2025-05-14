using UnityEngine;

namespace Viewer.Editor.Meshes
{
    static class StretchMeshes
    {
        public static void GenerateCylinder(int segments, string path)
        {
            (Mesh mesh, bool exists) = MeshData.CreateOrLoadMesh(path, $"Stretch Cylinder {segments}");

            MeshData.Merge(mesh,
                MeshData.CappedTube(
                    Vector3.forward * 0.5f, MeshData.CapType.Flat,
                    Vector3.forward * -0.5f, MeshData.CapType.Flat,
                    1, segments, 0,
                    0.0f, 0.5f,
                    Vector2.one, Vector2.zero
                )
            );

            mesh.bounds = new Bounds(Vector3.zero, Vector3.one);

            MeshData.SaveMesh(exists, mesh, path);
        }

        public static void GenerateBox(string path)
        {
            (Mesh mesh, bool exists) = MeshData.CreateOrLoadMesh(path, $"Stretch box");

            MeshData.Merge(mesh,
                MeshData.CappedTube(
                    Vector3.forward * 0.5f, MeshData.CapType.Flat,
                    Vector3.forward * -0.5f, MeshData.CapType.Flat,
                    1, 4, 0,
                    0.0f, 0.5f,
                    Vector2.one, Vector2.zero,
                    Mathf.PI * 0.25f
                )
            );

            mesh.bounds = new Bounds(Vector3.zero, Vector3.one);

            MeshData.SaveMesh(exists, mesh, path);
        }

        public static void GenerateGridLine(string path, int segments)
        {
            (Mesh mesh, bool exists) = MeshData.CreateOrLoadMesh(path, $"Grid Line ({segments})");

            MeshData.Merge(mesh,
                MeshData.CappedTube(
                    Vector3.forward * 0.5f, MeshData.CapType.Flat,
                    Vector3.forward * -0.5f, MeshData.CapType.Flat,
                    segments, 4, 0,
                    0.0f, 0.5f,
                    Vector2.one, Vector2.zero,
                    Mathf.PI * 0.25f
                )
            );

            mesh.bounds = new Bounds(Vector3.zero, Vector3.one);

            MeshData.SaveMesh(exists, mesh, path);
        }

        public static void GenerateCylinderWithRoundedCaps(int segments, int capSubdivisions, string path)
        {
            (Mesh mesh, bool exists) = MeshData.CreateOrLoadMesh(path, $"Stretch Cylinder with Rounded Caps {segments}x{capSubdivisions}");

            MeshData.Merge(mesh,
                MeshData.CappedTube(
                    Vector3.forward * 0.5f, MeshData.CapType.Round,
                    Vector3.forward * -0.5f, MeshData.CapType.Round,
                    1, segments, capSubdivisions,
                    0.0f, 0.5f,
                    Vector2.one, Vector2.zero
                )
            );

            mesh.bounds = new Bounds(Vector3.zero, Vector3.one);

            MeshData.SaveMesh(exists, mesh, path);
        }

        public static void GenerateCylinderWithOneRoundedCap(int segments, int capSubdivisions, string path)
        {
            (Mesh mesh, bool exists) = MeshData.CreateOrLoadMesh(path, $"Stretch Cylinder with one Rounded Cap {segments}x{capSubdivisions}");

            MeshData.Merge(mesh,
                MeshData.CappedTube(
                    Vector3.forward * 0.5f, MeshData.CapType.Round,
                    Vector3.forward * -0.5f, MeshData.CapType.None,
                    1, segments, capSubdivisions,
                    0.0f, 0.5f,
                    Vector2.one, Vector2.zero
                )
            );

            mesh.bounds = new Bounds(Vector3.zero, Vector3.one);

            MeshData.SaveMesh(exists, mesh, path);
        }

        public static void GenerateTorus(int ringSegments, int tubeSegments, string path)
        {
            (Mesh mesh, bool exists) = MeshData.CreateOrLoadMesh(path, $"Stretch Torus {tubeSegments}x{ringSegments}");

            var meshData = new MeshData();

            float majorRadius = 0.5f; // Distance from the center of the tube to the center of the torus
            float minorRadius = 0.5f; // Radius of the tube

            float angleScale = 1f / (Mathf.PI * 2f);

            // Generate vertices and thickness (tangents)
            foreach (var (ringDir, angle) in MeshData.IterateArc(ringSegments, Vector3.forward))
            {
                var ringCenter = new Vector3(ringDir.x * majorRadius, ringDir.y * majorRadius, 0);

                float uv = UpDown(angle * angleScale);

                foreach (var (tubeDir, _) in MeshData.IterateArc(tubeSegments, Vector3.forward))
                {
                    // Direction vector from ring center to tube surface
                    var dir = new Vector3(ringDir.x * tubeDir.x, ringDir.y * tubeDir.x, tubeDir.y);

                    meshData.AddVertex(
                        ringCenter,
                        new Vector4(dir.x * minorRadius, dir.y * minorRadius, dir.z * minorRadius, 0f),
                        new Vector2(uv, 0)
                    );
                }
            }

            int verticesPerRing = tubeSegments;
            for (int ring = 0; ring < ringSegments; ring++)
            {
                int ringStart = ring * verticesPerRing;
                int nextRingStart = (ring + 1) % ringSegments * verticesPerRing;

                for (int tube = 0; tube < tubeSegments; tube++)
                {
                    int current = ringStart + tube;
                    int next = ringStart + (tube + 1) % tubeSegments;
                    int currentNextRing = nextRingStart + tube;
                    int nextNextRing = nextRingStart + (tube + 1) % tubeSegments;

                    meshData.AddQuad(current, currentNextRing, nextNextRing, next);
                }
            }

            MeshData.Merge(mesh, meshData);

            mesh.bounds = new Bounds(Vector3.zero, Vector3.one * (majorRadius + minorRadius) * 2);

            MeshData.SaveMesh(exists, mesh, path);
        }

        private static float UpDown(float value)
        {
            float wrappedValue = (value * 2f) % 2f;

            return Mathf.Clamp01(Mathf.Clamp01(wrappedValue) - Mathf.Clamp01(wrappedValue - 1f));
        }
    }
}