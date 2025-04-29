using UnityEngine;

namespace Viewer.Editor.Meshes
{
    static class AngleMeshes
    {
        public static void GenerateArc(int segments, string path)
        {
            (Mesh mesh, bool exists) = MeshData.CreateOrLoadMesh(path, $"Angle Arc Mesh {segments}");

            var data = new MeshData();

            float outerRadius = 0.5f;

            float thicknessValue = 0.5f;

            float angleIncrement = 1f / (segments);

            var top = new Vector4(thicknessValue, 0, 0, 0f);

            var bottom = new Vector4(-thicknessValue, 0, 0, 0f);

            int topHub = data.AddVertex(new Vector3(0, 0, 0), top, new Vector2(0, 0));

            int bottomHub = data.AddVertex(new Vector3(0, 0, 0), bottom, new Vector2(0, 0));

            for (int i = 0; i <= segments; i++)
            {
                float angle = i * angleIncrement;

                data.AddVertex(new Vector3(0, outerRadius, angle), top, new Vector2(angle, 1));

                data.AddVertex(new Vector3(0, outerRadius, angle), bottom, new Vector2(angle, 1));
            }

            // Top and bottom arc face triangles 
            for (int i = 0; i < segments; i++)
            {
                int current = i * 2 + 2;
                int next = (i + 1) * 2 + 2;

                data.AddTriangle(topHub, current, next);
                data.AddTriangle(bottomHub, ++next, ++current);
            }

            // Add outer bands that join top and bottom arc faces 
            for (int i = 0; i < segments; i++)
            {
                int topCurrent = i * 2 + 2;
                int topNext = (i + 1) * 2 + 2;

                int bottomCurrent = topCurrent + 1;
                int bottomNext = topNext + 1;

                data.AddQuad(topCurrent, bottomCurrent, bottomNext, topNext);
            }

            // Add the end faces 
            if (segments > 1)
            {
                int topNext = 2;
                int bottomNext = topNext + 1;

                data.AddQuad(topHub, bottomHub, bottomNext, topNext);

                topNext = segments * 2 + 2;
                bottomNext = topNext + 1;

                data.AddQuad(bottomHub, topHub, topNext, bottomNext);
            }

            MeshData.Merge(mesh, data);

            mesh.bounds = new Bounds(Vector3.zero, Vector3.one);

            MeshData.SaveMesh(exists, mesh, path);
        }

        public static void GenerateArcLine(int segments, int tubeSegments, int capSubdivisions, float stopLength, string path)
        {
            (Mesh mesh, bool exists) = MeshData.CreateOrLoadMesh(path, $"Angle Line Arc {tubeSegments}x{capSubdivisions}");

            float outerRadius = 0.5f;
            float innerRadius = outerRadius - stopLength;

            float radius = 0;
            float thickness = 0.5f;

            Vector3 startHub = new Vector3(0, 0, 0);
            Vector3 startTop = new Vector3(0, outerRadius, 0);

            Vector3 endHub = new Vector3(0, 0, 1);
            Vector3 endTop = new Vector3(0, outerRadius, 1);

            MeshData.Merge(mesh,
                MeshData.CappedTube(startTop, MeshData.CapType.Round, startHub, MeshData.CapType.Round, 1, tubeSegments, capSubdivisions, radius, thickness, new Vector2(-1, 1), new Vector2(1, 0)),
                MeshData.Tube(startTop, endTop, segments, tubeSegments, radius, thickness, Vector2.one, Vector2.zero),
                MeshData.CappedTube(endTop, MeshData.CapType.Round, endHub, MeshData.CapType.Round, 1, tubeSegments, capSubdivisions, radius, thickness, new Vector2(0, 1), new Vector2(1, 0))
            );

            mesh.bounds = new Bounds(Vector3.zero, Vector3.one);

            MeshData.SaveMesh(exists, mesh, path);
        }

        public static void GenerateNeedle(int tubeSegments, int capSubdivisions, float stopLength, string path)
        {
            (Mesh mesh, bool exists) = MeshData.CreateOrLoadMesh(path, $"Angle Needle {tubeSegments}x{capSubdivisions}");

            float outerRadius = 0.5f;

            MeshData.Merge(mesh,
                MeshData.CappedTube(
                    new Vector3(0, outerRadius, 0), MeshData.CapType.Round,
                    new Vector3(0, outerRadius - stopLength, 0), MeshData.CapType.Round,
                    1, tubeSegments, capSubdivisions,
                    0, 0.5f,
                    new Vector2(0, 1),
                    new Vector2(0, 0)
                )
            );

            mesh.bounds = new Bounds(Vector3.zero, Vector3.one);

            MeshData.SaveMesh(exists, mesh, path);
        }
    }
}