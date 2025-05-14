using UnityEditor;
using Viewer.Editor.Meshes;

namespace Viewer.Editor
{
    public class MenuItems
    {
        [MenuItem("Viewer/Generate All Meshes")]
        private static void GenerateAllMeshes()
        {
            StretchMeshes.GenerateBox("Assets/Viewer/Resources/Stretchable Meshes/Box.asset");
            StretchMeshes.GenerateGridLine("Assets/Viewer/Resources/Stretchable Meshes/Grid Line.asset", 8);
            StretchMeshes.GenerateCylinder(6, "Assets/Viewer/Resources/Stretchable Meshes/Cylinder.asset");
            StretchMeshes.GenerateCylinderWithRoundedCaps(12, 4, "Assets/Viewer/Resources/Stretchable Meshes/Capsule.asset");
            StretchMeshes.GenerateCylinderWithOneRoundedCap(12, 4, "Assets/Viewer/Resources/Stretchable Meshes/Height Stick.asset");
            StretchMeshes.GenerateTorus(72, 12, "Assets/Viewer/Resources/Stretchable Meshes/Circle.asset");

            Sphere.GenerateMesh(2, "Assets/Viewer/Resources/Stretchable Meshes/Sphere.asset");

            AngleMeshes.GenerateArc(72, "Assets/Viewer/Resources/Stretchable Meshes/Angle Arc.asset");
            AngleMeshes.GenerateArcLine(72, 12, 4, 0.2f, "Assets/Viewer/Resources/Stretchable Meshes/Angle Line Arc.asset");
            AngleMeshes.GenerateNeedle(12, 4, 0.5f, "Assets/Viewer/Resources/Stretchable Meshes/Angle Needle.asset");
        }
    }
}