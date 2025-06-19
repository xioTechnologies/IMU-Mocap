using System.Runtime.InteropServices;
using UnityEngine;

namespace Viewer.Runtime.Primitives.Batching
{
    public sealed class AngleDrawBatch : DrawBatch<AngleDrawBatch.InstanceData>
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct InstanceData
        {
            public Matrix4x4 Transform;
            public Vector4 Color;

            public float StartAngle;
            public float EndAngle;

            public float Padding0;
            public float Padding1;

            public float Thickness // repurpose m33 to store thickness
            {
                get => Transform.m33;
                set => Transform.m33 = value;
            }
        }

        public AngleDrawBatch(int max, Mesh mesh, Material material, int layer) : base(max, mesh, material, layer) { }

        public void Add(Vector3 position, Quaternion rotation, float radius, float thickness, Color color, float startAngle, float endAngle, bool mirror)
        {
            const float angleScale = 1f / 360f;

            if (mirror == true) rotation *= Quaternion.Euler(180, 0, 0);

            InstanceData instance = new InstanceData
            {
                Transform = Matrix4x4.TRS(position, rotation, Vector3.one * radius),
                Color = color,
                StartAngle = startAngle * angleScale,
                EndAngle = endAngle * angleScale,
                Thickness = thickness
            };

            if (Append(ref instance) == false) return;

            Encapsulate(Utils.CircleBounds(position, rotation * Vector3.up, radius));
        }
    }
}