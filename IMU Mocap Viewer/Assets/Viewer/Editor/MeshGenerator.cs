using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Viewer.Editor
{
    public class MeshGenerator
    {
        [MenuItem("Viewer/Generate All Meshes")]
        private static void GenerateAllMeshes()
        {
            GenerateStretchBoxMesh();
            GenerateStretchCylinderMesh6();
            GenerateStretchCylinderMeshWithRoundedCaps12();
            GenerateStretchIcosphereMesh2();
            GenerateStretchSphereMesh24x24();
            GenerateStretchTorusMesh36x16();
        }

        [MenuItem("Viewer/Generate Box Mesh")]
        private static void GenerateStretchBoxMesh()
        {
            // Meshes that are stretched are elongated down the z axis

            // Create a new mesh
            var mesh = new Mesh
            {
                name = "Stretch Box"
            };

            // Define the vertices of a unit cube centered at (0,0,0)
            var vertices = new Vector3[]
            {
                // near faces
                new(0, 0, -0.5f), // 0
                new(0, 0, -0.5f), // 1
                new(0, 0, -0.5f), // 2
                new(0, 0, -0.5f), // 3

                // far faces
                new(0, 0, 0.5f), // 4
                new(0, 0, 0.5f), // 5
                new(0, 0, 0.5f), // 6
                new(0, 0, 0.5f) // 7
            };

            var thickness = new Vector4[]
            {
                // near faces
                new(-0.5f, -0.5f, 0f, 0f), // 0
                new(0.5f, -0.5f, 0f, 0f), // 1
                new(0.5f, 0.5f, 0f, 0f), // 2
                new(-0.5f, 0.5f, 0f, 0f), // 3

                // far faces
                new(-0.5f, -0.5f, 0f, 0f), // 4
                new(0.5f, -0.5f, 0f, 0f), // 5
                new(0.5f, 0.5f, 0f, 0f), // 6
                new(-0.5f, 0.5f, 0f, 0f) // 7
            };

            // Define UV coordinates for each vertex
            var uvs = new Vector2[]
            {
                new(0, 0), // 0
                new(0, 0), // 1
                new(0, 0), // 2
                new(0, 0), // 3

                new(1, 1), // 4
                new(1, 1), // 5
                new(1, 1), // 6
                new(1, 1) // 7
            };

            // Define the triangles that make up the cube's faces
            int[] triangles =
            {
                0, 1, 2,
                0, 2, 3,

                4, 6, 5,
                4, 7, 6,

                0, 5, 1,
                0, 4, 5,

                2, 7, 3,
                2, 6, 7,

                0, 7, 4,
                0, 3, 7,

                1, 6, 2,
                1, 5, 6
            };

            // Assign data to the mesh
            mesh.vertices = vertices;
            mesh.tangents = thickness;
            mesh.uv = uvs;
            mesh.triangles = triangles;

            mesh.bounds = new Bounds(Vector3.zero, Vector3.one);
            // Save the mesh as an asset
            string path = "Assets/Viewer/Resources/Stretchable Meshes/Stretch Box.asset";

            AssetDatabase.CreateAsset(mesh, path);

            AssetDatabase.SaveAssets();

            // Log the completion
            Debug.Log("Cube mesh saved to " + path);
        }

        private static void GenerateStretchCylinderMesh(int segments, string path)
        {
            // Create a new mesh
            var mesh = new Mesh
            {
                name = $"Stretch Cylinder {segments}"
            };

            // Define lists for vertices, tangents (thickness), uvs, and triangles
            var vertices = new List<Vector3>();
            var thickness = new List<Vector4>();
            var uvs = new List<Vector2>();
            var triangles = new List<int>();

            // Parameters for the cylinder
            float radius = 0.5f;
            float halfHeight = 0.5f;
            float angleIncrement = 2 * Mathf.PI / segments;

            // Generate vertices and thickness (tangents)
            for (int i = 0; i < segments; i++)
            {
                float angle = i * angleIncrement;
                float x = radius * Mathf.Cos(angle);
                float y = radius * Mathf.Sin(angle);

                // Bottom circle (z = -0.5f)
                vertices.Add(new Vector3(0, 0, -halfHeight));
                thickness.Add(new Vector4(x, y, 0f, 0f));
                uvs.Add(new Vector2(0, 0));

                // Top circle (z = 0.5f)
                vertices.Add(new Vector3(0, 0, halfHeight));
                thickness.Add(new Vector4(x, y, 0f, 0f));
                uvs.Add(new Vector2(1, 1));
            }

            // Generate side triangles
            for (int i = 0; i < segments; i++)
            {
                int bottomCurrent = i * 2;
                int topCurrent = bottomCurrent + 1;
                int bottomNext = (bottomCurrent + 2) % (segments * 2);
                int topNext = (bottomCurrent + 3) % (segments * 2);

                // First triangle of quad
                triangles.Add(bottomCurrent);
                triangles.Add(bottomNext);
                triangles.Add(topCurrent);

                // Second triangle of quad
                triangles.Add(bottomNext);
                triangles.Add(topNext);
                triangles.Add(topCurrent);
            }

            // Add center points for caps
            vertices.Add(new Vector3(0, 0, -halfHeight)); // Bottom center
            thickness.Add(new Vector4(0, 0, -radius, 0f));
            uvs.Add(new Vector2(0f, 0f));
            int bottomCenterIndex = vertices.Count - 1;

            vertices.Add(new Vector3(0, 0, halfHeight)); // Top center
            thickness.Add(new Vector4(0, 0, radius, 0f));
            uvs.Add(new Vector2(1f, 1f));
            int topCenterIndex = vertices.Count - 1;

            // Generate bottom cap triangles
            for (int i = 0; i < segments; i++)
            {
                int current = i * 2;
                int next = (current + 2) % (segments * 2);
                triangles.Add(bottomCenterIndex);
                triangles.Add(next);
                triangles.Add(current);
            }

            // Generate top cap triangles
            for (int i = 0; i < segments; i++)
            {
                int current = i * 2 + 1;
                int next = (current + 2) % (segments * 2);
                triangles.Add(topCenterIndex);
                triangles.Add(current);
                triangles.Add(next);
            }

            // Assign data to the mesh
            mesh.vertices = vertices.ToArray();
            mesh.tangents = thickness.ToArray();
            mesh.uv = uvs.ToArray();
            mesh.triangles = triangles.ToArray();

            mesh.bounds = new Bounds(Vector3.zero, Vector3.one);

            // Save the mesh as an asset
            AssetDatabase.CreateAsset(mesh, path);
            AssetDatabase.SaveAssets();

            // Log the completion
            Debug.Log($"Cylinder mesh with {segments} segments saved to {path}");
        }

        [MenuItem("Viewer/Generate Cylinder Mesh (6)")]
        private static void GenerateStretchCylinderMesh6() => GenerateStretchCylinderMesh(6, "Assets/Viewer/Resources/Stretchable Meshes/Cylinder.asset");

        private static void GenerateStretchCylinderMeshWithRoundedCaps(int segments, int capSubdivisions, string path)
        {
            var mesh = new Mesh { name = $"Stretch Cylinder with Rounded Caps {segments}x{capSubdivisions}" };

            var vertices = new List<Vector3>();
            var thickness = new List<Vector4>();
            var uvs = new List<Vector2>();
            var triangles = new List<int>();

            float angleIncrement = 2 * Mathf.PI / segments;
            float radius = 0.5f;
            float halfHeight = 0.5f;

            // Generate main cylinder body
            for (int i = 0; i < segments; i++)
            {
                float angle = i * angleIncrement;
                float x = radius * Mathf.Cos(angle);
                float y = radius * Mathf.Sin(angle);

                vertices.Add(new Vector3(0, 0, -halfHeight));
                thickness.Add(new Vector4(x, y, 0f, 0f));
                uvs.Add(new Vector2(0, 0));

                vertices.Add(new Vector3(0, 0, halfHeight));
                thickness.Add(new Vector4(x, y, 0f, 0f));
                uvs.Add(new Vector2(1, 0));
            }

            // Body triangles (unchanged)
            for (int i = 0; i < segments; i++)
            {
                int bottomCurrent = i * 2;
                int topCurrent = bottomCurrent + 1;
                int bottomNext = (bottomCurrent + 2) % (segments * 2);
                int topNext = (bottomCurrent + 3) % (segments * 2);

                triangles.Add(bottomCurrent);
                triangles.Add(bottomNext);
                triangles.Add(topCurrent);

                triangles.Add(bottomNext);
                triangles.Add(topNext);
                triangles.Add(topCurrent);
            }

            // Cap centers
            int bottomCenterIndex = vertices.Count;
            vertices.Add(new Vector3(0, 0, -halfHeight));
            thickness.Add(new Vector4(0, 0, -radius, 0f));
            uvs.Add(new Vector2(0f, 0f));

            // Bottom cap rings
            for (int ring = 1; ring <= capSubdivisions; ring++)
            {
                float theta = Mathf.PI / 2 * (1f - ring / (float)capSubdivisions);
                float xyScale = radius * Mathf.Cos(theta);
                float z = radius * -Mathf.Sin(theta);

                for (int i = 0; i < segments; i++)
                {
                    float angle = i * angleIncrement;
                    float x = xyScale * Mathf.Cos(angle);
                    float y = xyScale * Mathf.Sin(angle);

                    vertices.Add(new Vector3(0, 0, -halfHeight));
                    thickness.Add(new Vector4(x, y, z, 0f));
                    uvs.Add(new Vector2(0, 0));
                }
            }

            int topCenterIndex = vertices.Count;
            vertices.Add(new Vector3(0, 0, halfHeight));
            thickness.Add(new Vector4(0, 0, radius, 0f));
            uvs.Add(new Vector2(1f, 0f));

            // Top cap rings
            for (int ring = 1; ring <= capSubdivisions; ring++)
            {
                float theta = Mathf.PI / 2 * (1f - ring / (float)capSubdivisions);
                float xyScale = radius * Mathf.Cos(theta);
                float z = radius * Mathf.Sin(theta);

                for (int i = 0; i < segments; i++)
                {
                    float angle = i * angleIncrement;
                    float x = xyScale * Mathf.Cos(angle);
                    float y = xyScale * Mathf.Sin(angle);

                    vertices.Add(new Vector3(0, 0, halfHeight));
                    thickness.Add(new Vector4(x, y, z, 0f));
                    uvs.Add(new Vector2(1, 0));
                }
            }

            // Cap triangles unchanged...
            int bottomCapStartIndex = bottomCenterIndex + 1;
            int topCapStartIndex = topCenterIndex + 1;

            for (int ring = 0; ring < capSubdivisions; ring++)
            {
                int ringStart = bottomCapStartIndex + ring * segments;

                for (int i = 0; i < segments; i++)
                {
                    int current = ringStart + i;
                    int next = ringStart + (i + 1) % segments;

                    if (ring == 0)
                    {
                        triangles.Add(bottomCenterIndex);
                        triangles.Add(next);
                        triangles.Add(current);
                    }
                    else
                    {
                        int currentPrev = current - segments;
                        int nextPrev = next - segments;

                        triangles.Add(currentPrev);
                        triangles.Add(next);
                        triangles.Add(current);

                        triangles.Add(currentPrev);
                        triangles.Add(nextPrev);
                        triangles.Add(next);
                    }
                }
            }

            for (int ring = 0; ring < capSubdivisions; ring++)
            {
                int ringStart = topCapStartIndex + ring * segments;

                for (int i = 0; i < segments; i++)
                {
                    int current = ringStart + i;
                    int next = ringStart + (i + 1) % segments;

                    if (ring == 0)
                    {
                        triangles.Add(topCenterIndex);
                        triangles.Add(current);
                        triangles.Add(next);
                    }
                    else
                    {
                        int currentPrev = current - segments;
                        int nextPrev = next - segments;

                        triangles.Add(currentPrev);
                        triangles.Add(current);
                        triangles.Add(next);

                        triangles.Add(currentPrev);
                        triangles.Add(next);
                        triangles.Add(nextPrev);
                    }
                }
            }

            mesh.vertices = vertices.ToArray();
            mesh.tangents = thickness.ToArray();
            mesh.uv = uvs.ToArray();
            mesh.triangles = triangles.ToArray();
            mesh.bounds = new Bounds(Vector3.zero, Vector3.one);

            AssetDatabase.CreateAsset(mesh, path);
            AssetDatabase.SaveAssets();
        }

        [MenuItem("Viewer/Generate Capsule Mesh (12, 4)")]
        private static void GenerateStretchCylinderMeshWithRoundedCaps12() => GenerateStretchCylinderMeshWithRoundedCaps(12, 4, "Assets/Viewer/Resources/Stretchable Meshes/Capsule.asset");

        private static void GenerateStretchIcosphereMesh(int subdivisions, string path)
        {
            // Create a new mesh
            var mesh = new Mesh
            {
                name = $"Stretch Icosphere Subdivisions {subdivisions}"
            };

            // Lists to hold mesh data
            var vertices = new List<Vector3>();
            var thickness = new List<Vector4>();
            var uvs = new List<Vector2>();
            var triangles = new List<int>();

            // Sphere parameters
            float radius = 0.5f;

            // Golden ratio
            float t = (1.0f + Mathf.Sqrt(5.0f)) / 2.0f;

            // Initial icosahedron vertices
            var initialVertices = new List<Vector3>
            {
                new(-1, t, 0),
                new(1, t, 0),
                new(-1, -t, 0),
                new(1, -t, 0),

                new(0, -1, t),
                new(0, 1, t),
                new(0, -1, -t),
                new(0, 1, -t),

                new(t, 0, -1),
                new(t, 0, 1),
                new(-t, 0, -1),
                new(-t, 0, 1)
            };

            // Normalize the vertices to fit within the unit sphere
            for (int i = 0; i < initialVertices.Count; i++)
            {
                initialVertices[i] = initialVertices[i].normalized;
            }

            // Initial icosahedron faces (triangles)
            var initialFaces = new List<int[]>
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

            // Map to keep track of vertices and their indices
            var vertexIndexDict = new Dictionary<Vector3, int>(new Vector3Comparer());

            // Add initial vertices to the lists
            foreach (Vector3 v in initialVertices)
            {
                // All vertices are placed at the origin
                vertices.Add(Vector3.zero);

                // Thickness stores the normalized position scaled by the radius
                thickness.Add(new Vector4(v.x * radius, v.y * radius, v.z * radius, 0f));

                // UV coordinates can be calculated if needed
                uvs.Add(Vector2.zero);

                // Map the vertex to its index
                vertexIndexDict[v] = vertices.Count - 1;
            }

            // Start with the initial faces
            List<int[]> faces = initialFaces;

            // Subdivide faces to increase LOD
            for (int i = 0; i < subdivisions; i++)
            {
                var newFaces = new List<int[]>();
                var midPointCache = new Dictionary<long, int>();

                foreach (int[] tri in faces)
                {
                    int a = tri[0];
                    int b = tri[1];
                    int c = tri[2];

                    // Get indices of midpoints
                    int ab = GetMidPointIndex(a, b, ref vertices, ref thickness, ref uvs, midPointCache, radius);
                    int bc = GetMidPointIndex(b, c, ref vertices, ref thickness, ref uvs, midPointCache, radius);
                    int ca = GetMidPointIndex(c, a, ref vertices, ref thickness, ref uvs, midPointCache, radius);

                    // Create new faces from subdivided triangles
                    newFaces.Add(new[] { a, ab, ca });
                    newFaces.Add(new[] { b, bc, ab });
                    newFaces.Add(new[] { c, ca, bc });
                    newFaces.Add(new[] { ab, bc, ca });
                }

                faces = newFaces;
            }

            // Build triangles for the mesh
            foreach (int[] tri in faces)
            {
                triangles.Add(tri[0]);
                triangles.Add(tri[1]);
                triangles.Add(tri[2]);
            }

            // Assign data to the mesh
            mesh.vertices = vertices.ToArray();
            mesh.tangents = thickness.ToArray();
            mesh.uv = uvs.ToArray();
            mesh.triangles = triangles.ToArray();

            // Set mesh bounds
            mesh.bounds = new Bounds(Vector3.zero, Vector3.one);

            // Save the mesh asset
            AssetDatabase.CreateAsset(mesh, path);
            AssetDatabase.SaveAssets();

            // Log completion
            Debug.Log($"Icosphere mesh with {subdivisions} subdivisions saved to {path}");
        }

        [MenuItem("Viewer/Generate Icosphere Mesh (2)")]
        private static void GenerateStretchIcosphereMesh2() => GenerateStretchIcosphereMesh(2, "Assets/Viewer/Resources/Stretchable Meshes/Icosphere.asset");

        private static void GenerateStretchSphereMesh(int latitudeSegments, int longitudeSegments, string path)
        {
            // Create a new mesh
            var mesh = new Mesh
            {
                name = $"Stretch Sphere {latitudeSegments}x{longitudeSegments}"
            };

            // Define lists for vertices, tangents (thickness), uvs, and triangles
            var vertices = new List<Vector3>();
            var thickness = new List<Vector4>();
            var uvs = new List<Vector2>();
            var triangles = new List<int>();

            // Parameters for the sphere
            float radius = 0.5f;

            // Generate vertices and thickness (tangents)
            for (int lat = 0; lat <= latitudeSegments; lat++)
            {
                float latFraction = (float)lat / latitudeSegments;
                float theta = latFraction * Mathf.PI; // From 0 to PI

                float sinTheta = Mathf.Sin(theta);
                float cosTheta = Mathf.Cos(theta);

                for (int lon = 0; lon <= longitudeSegments; lon++)
                {
                    float lonFraction = (float)lon / longitudeSegments;
                    float phi = lonFraction * 2 * Mathf.PI; // From 0 to 2PI

                    float sinPhi = Mathf.Sin(phi);
                    float cosPhi = Mathf.Cos(phi);

                    // Direction vector from center to point on sphere surface
                    float x = sinTheta * cosPhi;
                    float y = sinTheta * sinPhi;
                    float z = cosTheta;

                    // Vertex at the center
                    vertices.Add(new Vector3(0, 0, 0));

                    // Thickness stores the direction vector
                    thickness.Add(new Vector4(x * radius, y * radius, z * radius, 0f));

                    // UV coordinates
                    uvs.Add(new Vector2(lonFraction, latFraction));
                }
            }

            // Generate triangles
            int vertexCountPerRow = longitudeSegments + 1;
            for (int lat = 0; lat < latitudeSegments; lat++)
            {
                for (int lon = 0; lon < longitudeSegments; lon++)
                {
                    int current = lat * vertexCountPerRow + lon;
                    int next = current + vertexCountPerRow;

                    // First triangle of quad
                    triangles.Add(current);
                    triangles.Add(current + 1);
                    triangles.Add(next);

                    // Second triangle of quad
                    triangles.Add(next);
                    triangles.Add(current + 1);
                    triangles.Add(next + 1);
                }
            }

            // Assign data to the mesh
            mesh.vertices = vertices.ToArray();
            mesh.tangents = thickness.ToArray();
            mesh.uv = uvs.ToArray();
            mesh.triangles = triangles.ToArray();

            // Set the bounds of the mesh
            mesh.bounds = new Bounds(Vector3.zero, Vector3.one);

            // Save the mesh as an asset
            AssetDatabase.CreateAsset(mesh, path);
            AssetDatabase.SaveAssets();

            // Log the completion
            Debug.Log($"Sphere mesh with {latitudeSegments} latitude segments and {longitudeSegments} longitude segments saved to {path}");
        }

        [MenuItem("Viewer/Generate Sphere Mesh (24x24)")]
        private static void GenerateStretchSphereMesh24x24() => GenerateStretchSphereMesh(24, 24, "Assets/Viewer/Resources/Stretchable Meshes/Sphere.asset");

        private static void GenerateStretchTorusMesh(int ringSegments, int tubeSegments, string path)
        {
            // Create a new mesh
            var mesh = new Mesh
            {
                name = $"Stretch Torus {tubeSegments}x{ringSegments}"
            };

            // Lists to hold mesh data
            var vertices = new List<Vector3>();
            var thickness = new List<Vector4>();
            var uvs = new List<Vector2>();
            var triangles = new List<int>();

            // Torus parameters
            float majorRadius = 0.5f; // Distance from the center of the tube to the center of the torus
            float minorRadius = 0.5f; // Radius of the tube

            // Generate vertices and thickness (tangents)
            for (int ring = 0; ring <= ringSegments; ring++)
            {
                float ringFraction = (float)ring / ringSegments;
                float theta = ringFraction * 2 * Mathf.PI; // Angle around the torus center

                // Calculate the center of the current ring
                float cosTheta = Mathf.Cos(theta);
                float sinTheta = Mathf.Sin(theta);
                var ringCenter = new Vector3(cosTheta * majorRadius, sinTheta * majorRadius, 0);

                for (int tube = 0; tube <= tubeSegments; tube++)
                {
                    float tubeFraction = (float)tube / tubeSegments;
                    float phi = tubeFraction * 2 * Mathf.PI; // Angle around the tube

                    // Calculate the position of the vertex on the tube circle
                    float cosPhi = Mathf.Cos(phi);
                    float sinPhi = Mathf.Sin(phi);

                    // Direction vector from ring center to tube surface
                    var dir = new Vector3(cosTheta * cosPhi, sinTheta * cosPhi, sinPhi);

                    // Vertex at the ring center
                    vertices.Add(ringCenter);

                    // Thickness stores the direction vector scaled by the minor radius
                    thickness.Add(new Vector4(dir.x * minorRadius, dir.y * minorRadius, dir.z * minorRadius, 0f));

                    // UV coordinates
                    uvs.Add(new Vector2(ringFraction, tubeFraction));
                }
            }

            // Generate triangles
            int verticesPerRing = tubeSegments + 1;
            for (int ring = 0; ring < ringSegments; ring++)
            {
                int ringStart = ring * verticesPerRing;
                int nextRingStart = (ring + 1) % ringSegments * verticesPerRing;

                for (int tube = 0; tube < tubeSegments; tube++)
                {
                    int current = ringStart + tube;
                    int next = ringStart + tube + 1;
                    int currentNextRing = nextRingStart + tube;
                    int nextNextRing = nextRingStart + tube + 1;

                    // First triangle of quad
                    triangles.Add(current);
                    triangles.Add(currentNextRing);
                    triangles.Add(next);

                    // Second triangle of quad
                    triangles.Add(next);
                    triangles.Add(currentNextRing);
                    triangles.Add(nextNextRing);
                }
            }

            // Assign data to the mesh
            mesh.vertices = vertices.ToArray();
            mesh.tangents = thickness.ToArray();
            mesh.uv = uvs.ToArray();
            mesh.triangles = triangles.ToArray();

            // Set mesh bounds
            mesh.bounds = new Bounds(Vector3.zero, Vector3.one * (majorRadius + minorRadius) * 2);

            // Save the mesh asset
            AssetDatabase.CreateAsset(mesh, path);
            AssetDatabase.SaveAssets();

            // Log completion
            Debug.Log($"Torus mesh with {tubeSegments} tube segments and {ringSegments} ring segments saved to {path}");
        }

        [MenuItem("Viewer/Generate Circle Mesh (36x12)")]
        private static void GenerateStretchTorusMesh36x16() => GenerateStretchTorusMesh(36, 12, "Assets/Viewer/Resources/Stretchable Meshes/Circle.asset");

        private static int GetMidPointIndex(int indexA, int indexB, ref List<Vector3> vertices, ref List<Vector4> thickness, ref List<Vector2> uvs, Dictionary<long, int> midPointCache, float radius)
        {
            // Ensure consistent key ordering
            int smallerIndex = Mathf.Min(indexA, indexB);
            int greaterIndex = Mathf.Max(indexA, indexB);
            long key = ((long)smallerIndex << 32) + greaterIndex;

            // Check if midpoint already calculated
            if (midPointCache.TryGetValue(key, out int ret))
            {
                return ret;
            }

            // Get positions from thickness (tangents)
            var pointA = new Vector3(thickness[indexA].x, thickness[indexA].y, thickness[indexA].z);
            var pointB = new Vector3(thickness[indexB].x, thickness[indexB].y, thickness[indexB].z);

            // Calculate midpoint and normalize
            Vector3 middle = (pointA + pointB) / 2.0f;
            middle.Normalize();
            middle *= radius;

            // Add new vertex at origin
            vertices.Add(Vector3.zero);

            // Store the direction vector in thickness
            thickness.Add(new Vector4(middle.x, middle.y, middle.z, 0f));

            // UVs can be computed if needed
            uvs.Add(Vector2.zero);

            int newIndex = vertices.Count - 1;

            // Store midpoint index in cache
            midPointCache.Add(key, newIndex);

            return newIndex;
        }

        // Custom comparer for Vector3 keys in dictionary
        private class Vector3Comparer : IEqualityComparer<Vector3>
        {
            public bool Equals(Vector3 v1, Vector3 v2) => v1.Equals(v2);

            public int GetHashCode(Vector3 v) => v.GetHashCode();
        }
    }
}