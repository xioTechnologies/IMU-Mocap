using System.Runtime.InteropServices;
using UnityEngine;

namespace Viewer.Runtime.Primitives.Batching
{
    public sealed class StretchableDrawBatch : DrawBatch<StretchableDrawBatch.InstanceData>
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct InstanceData
        {
            public Matrix4x4 Transform;
            public Vector4 NearColor;
            public Vector4 FarColor;

            public float Thickness // repurpose m33 to store thickness
            {
                get => Transform.m33;
                set => Transform.m33 = value;
            }
        }

        public StretchableDrawBatch(int max, Mesh mesh, Material material, int layer) : base(max, mesh, material, layer) { }

        public void Add(Vector3 position, Quaternion rotation, float scale, float thickness, Color nearColor, Color farColor)
        {
            InstanceData instance = new InstanceData
            {
                Transform = Matrix4x4.TRS(position, rotation, Vector3.one * scale),
                NearColor = nearColor,
                FarColor = farColor,
                Thickness = thickness
            };

            if (Append(ref instance) == false) return;

            Encapsulate(position);
        }
    }
}