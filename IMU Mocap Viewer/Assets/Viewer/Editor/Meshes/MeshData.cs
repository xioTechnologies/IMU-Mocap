using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Viewer.Runtime;
using Bounds = UnityEngine.Bounds;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;
using Vector4 = UnityEngine.Vector4;

namespace Viewer.Editor.Meshes
{
    public class MeshData
    {
        public readonly List<Vector3> Vertices = new();
        public readonly List<Vector4> Thickness = new();
        public readonly List<Vector2> UVs = new();
        public readonly List<int> Triangles = new();

        public void AddTriangle(int a, int b, int c, bool flipNormals = false)
        {
            Triangles.Add(a);
            
            (b, c) = flipNormals ? (c, b) : (b, c);
        
            Triangles.Add(b);
            Triangles.Add(c);
        }

        public int AddVertex(Vector3 position, Vector4 thicknessValue, Vector2 uv)
        {
            int index = Vertices.Count;

            Vertices.Add(position);
            Thickness.Add(thicknessValue);
            UVs.Add(uv);

            return index;
        }

        public void AddQuad(int a, int b, int c, int d, bool flipNormals = false)
        {
            AddTriangle(a, b, c, flipNormals);

            AddTriangle(a, c, d, flipNormals);
        }

        public static IEnumerable<(Vector3 direction, float angle)> IterateArc(
            int segments,
            Vector3 axis,
            float startAngle = 0,
            float sweepAngle = 2 * Mathf.PI)
        {
            float angleIncrement = sweepAngle / segments;

            if (sweepAngle < 2 * Mathf.PI) angleIncrement = sweepAngle / (segments - 1);

            Quaternion toAxisRotation = Quaternion.FromToRotation(Vector3.forward, axis);

            for (int i = 0; i < segments; i++)
            {
                float angle = startAngle + i * angleIncrement;

                float x = Mathf.Cos(angle);
                float y = Mathf.Sin(angle);

                Vector3 localDirection = new Vector3(x, y, 0f);

                Vector3 rotatedDirection = toAxisRotation * localDirection;

                yield return (rotatedDirection, angle);
            }
        }
        
        public static MeshData Merge(params MeshData[] data) => Merge((IEnumerable<MeshData>)data);

        public static MeshData Merge(IEnumerable<MeshData> data)
        {
            var final = new MeshData();

            int vertexOffset = 0;
            foreach (MeshData meshData in data.Where(meshData => meshData != null))
            {
                final.Vertices.AddRange(meshData.Vertices);
                final.Thickness.AddRange(meshData.Thickness);
                final.UVs.AddRange(meshData.UVs);

                final.Triangles.AddRange(meshData.Triangles.Select(triangleIndex => triangleIndex + vertexOffset));

                vertexOffset += meshData.Vertices.Count;
            }

            return final;
        }

        public static void Merge(Mesh mesh, params MeshData[] data) => Merge(mesh, (IEnumerable<MeshData>)data);

        public static void Merge(Mesh mesh, IEnumerable<MeshData> data)
        {
            var finalVertices = new List<Vector3>();
            var finalThickness = new List<Vector4>();
            var finalUvs = new List<Vector2>();
            var finalTriangles = new List<int>();

            int vertexOffset = 0;
            foreach (MeshData meshData in data.Where(meshData => meshData != null))
            {
                finalVertices.AddRange(meshData.Vertices);
                finalThickness.AddRange(meshData.Thickness);
                finalUvs.AddRange(meshData.UVs);

                finalTriangles.AddRange(meshData.Triangles.Select(triangleIndex => triangleIndex + vertexOffset));

                vertexOffset += meshData.Vertices.Count;
            }

            mesh.vertices = finalVertices.ToArray();
            mesh.tangents = finalThickness.ToArray();
            mesh.uv = finalUvs.ToArray();
            mesh.triangles = finalTriangles.ToArray();
            mesh.bounds = new Bounds(Vector3.zero, Vector3.one * 2);
        }

        public static (Mesh mesh, bool exists) CreateOrLoadMesh(string path, string defaultName)
        {
            Mesh mesh = AssetDatabase.LoadAssetAtPath<Mesh>(path);
            
            bool exists = mesh != null;

            if (exists == false) mesh = new Mesh { name = defaultName };
                
            mesh.Clear();

            return (mesh, exists);
        }

        public static void SaveMesh(bool exists, Mesh mesh, string path)
        {
            if (exists == false) AssetDatabase.CreateAsset(mesh, path);
            else EditorUtility.SetDirty(mesh);

            AssetDatabase.SaveAssets();

            Debug.Log("Generated: " + path);
        }

        public static MeshData Tube(
            Vector3 start,
            Vector3 end,
            int sections,
            int segments,
            float radius,
            float thicknessScale,
            Vector2 uvScale,
            Vector2 uvOffset,
            float startAngle = 0,
            float sweepAngle = 2 * Mathf.PI
        )
        {
            Vector3 axis = (end - start).normalized;

            var data = new MeshData();

            for (int section = 0; section < sections; section++)
            {
                float t = section / (float)sections;
                Vector3 currentPos = Vector3.Lerp(start, end, t);

                foreach (var (dir, _) in IterateArc(segments, axis, startAngle, sweepAngle))
                {
                    data.AddVertex(
                        currentPos + dir * radius,
                        (dir * thicknessScale)._xyz0(),
                        new Vector2(section / (float)sections, dir.y * 0.5f + 0.5f) * uvScale + uvOffset
                    );
                }
            }

            foreach (var (dir, _) in IterateArc(segments, axis, startAngle, sweepAngle))
            {
                data.AddVertex(
                    end + dir * radius,
                    (dir * thicknessScale)._xyz0(),
                    new Vector2(1, dir.y * 0.5f + 0.5f) * uvScale + uvOffset
                );
            }

            for (int section = 0; section < sections; section++)
            {
                int sectionBase = section * segments;
                int nextSectionBase = (section + 1) * segments;

                for (int i = 0; i < segments; i++)
                {
                    int bottomCurrent = sectionBase + i;
                    int topCurrent = nextSectionBase + i;
                    int bottomNext = sectionBase + (i + 1) % segments;
                    int topNext = nextSectionBase + (i + 1) % segments;

                    if ((bottomNext == 0 || topNext == 0) && sweepAngle < Mathf.PI * 2) continue;

                    data.AddQuad(bottomCurrent, bottomNext, topNext, topCurrent);
                }
            }

            return data;
        }

        public static MeshData Disc(Vector3 offset, Vector3 axis, int segments, float radius, Vector3 thicknessOffset, float thickness, Vector2 uv, float startAngle, bool flipNormals)
        {
            var data = new MeshData();
            
            int centerIndex = data.Vertices.Count;

            data.AddVertex(offset, thicknessOffset._xyz0(), uv);

            foreach (var (dir, _) in IterateArc(segments, axis, startAngle))
            {
                data.AddVertex(
                    dir * radius + offset,
                    dir._xyz0() * thickness + thicknessOffset._xyz0(),
                    uv
                );
            }
            
            for (int i = 0; i < segments; i++)
            {
                int current = centerIndex + 1 + i;
                int next = centerIndex + 1 + ((i + 1) % segments);

                data.AddTriangle(centerIndex, current, next, flipNormals);
            }

            return data;
        }

        public static MeshData RoundCap(Vector3 offset, Vector3 axis, int segments, int subDivisions, float radius, float thickness, Vector2 uv, float startAngle, bool flipNormals)
        {
            var data = new MeshData();

            int centerIndex = data.Vertices.Count;
            
            var extrusionDir = axis * (flipNormals ? -thickness : thickness);

            data.AddVertex(offset, extrusionDir._xyz0(), uv);
            
            for (int ring = 1; ring <= subDivisions; ring++)
            {
                float theta = Mathf.PI / 2 * (1f - ring / (float)subDivisions);
                float xyScale = Mathf.Cos(theta);
                float z = (flipNormals ? -Mathf.Sin(theta) : Mathf.Sin(theta));

                foreach (var (dir, _) in IterateArc(segments, axis, startAngle))
                {
                    extrusionDir = dir * xyScale + axis * z;

                    data.AddVertex(
                        offset + extrusionDir._xy0() * radius,
                        extrusionDir._xyz0() * thickness,
                        uv
                    );
                }
            }
            
            int ringStartIndex = centerIndex + 1;

            for (int ring = 0; ring < subDivisions; ring++)
            {
                int ringStart = ringStartIndex + ring * segments;

                for (int i = 0; i < segments; i++)
                {
                    int current = ringStart + i;
                    int next = ringStart + (i + 1) % segments;

                    if (ring == 0)
                    {
                        data.AddTriangle(centerIndex, current, next, flipNormals);
                    }
                    else
                    {
                        int currentPrev = current - segments;
                        int nextPrev = next - segments;

                        data.AddQuad(currentPrev, current, next, nextPrev, flipNormals);
                    }
                }
            }

            return data;
        }

        public enum CapType
        {
            None,
            Flat,
            Round,
        }

        public static MeshData CappedTube(
            Vector3 top,
            CapType topCapType,
            Vector3 bottom,
            CapType bottomCapType,
            int segments,
            int tubeSegments,
            int capSubdivisions,
            float radius,
            float thickness,
            Vector2 uvScale,
            Vector2 uvOffset,
            float startAngle = 0)
        {
            var axis = (top - bottom).normalized;
            
            Vector2 bottomUV = new Vector2(0, 0) * uvScale + uvOffset;
            Vector2 topUV = new Vector2(1, 0) * uvScale + uvOffset;

            var meshData = Merge(
                Cap(bottom, bottomCapType, tubeSegments, capSubdivisions, radius, thickness, axis, bottomUV, startAngle, true),
                Tube(bottom, top, segments, tubeSegments, radius, thickness, uvScale, uvOffset, startAngle),
                Cap(top, topCapType, tubeSegments, capSubdivisions, radius, thickness, axis, topUV, startAngle, false)
            );
            
            return meshData;
        }

        private static MeshData Cap(Vector3 position, CapType cap, int tubeSegments, int capSubdivisions, float radius, float thickness, Vector3 axis, Vector2 uv, float startAngle, bool flipNormals)
        {
            return cap switch
            {
                CapType.None => new MeshData(),
                CapType.Flat => Disc(position, axis, tubeSegments, radius, Vector3.zero, thickness, uv, startAngle, flipNormals),
                CapType.Round => RoundCap(position, axis, tubeSegments, capSubdivisions, radius, thickness, uv, startAngle, flipNormals),
                _ => throw new ArgumentOutOfRangeException(nameof(cap), cap, null)
            };
        }
    }
}