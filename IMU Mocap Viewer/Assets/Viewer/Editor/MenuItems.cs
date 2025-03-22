using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Viewer.Editor.Meshes;

namespace Viewer.Editor
{
    public class MenuItems
    {
        [MenuItem("Viewer/Generate All Meshes")]
        private static void GenerateAllMeshes()
        {
            StretchMeshes.GenerateBox("Assets/Viewer/Resources/Stretchable Meshes/Box.asset");
            StretchMeshes.GenerateCylinder(6, "Assets/Viewer/Resources/Stretchable Meshes/Cylinder.asset");
            StretchMeshes.GenerateCylinderWithRoundedCaps(12, 4, "Assets/Viewer/Resources/Stretchable Meshes/Capsule.asset");
            StretchMeshes.GenerateTorus(72, 12, "Assets/Viewer/Resources/Stretchable Meshes/Circle.asset");
            
            Sphere.GenerateMesh(2, "Assets/Viewer/Resources/Stretchable Meshes/Icosphere.asset");
        }
    }
}
