using UnityEngine;

namespace Viewer.Runtime.Primitives.Batching
{
    public sealed class LineDrawBatch : DrawBatch<StretchableDrawBatch.InstanceData>
    {
        public LineDrawBatch(int max, Mesh mesh, Material material, int layer) : base(max, mesh, material, layer) { }

        public void Add(Vector3 start, Vector3 end, float thickness, Color nearColor, Color farColor)
        {
            if (thickness <= 0f) return;

            var distance = Vector3.Distance(start, end);

            if (distance <= 0.00001f) return;

            var direction = (end - start).normalized;
            var center = (start + end) / 2f;
            var rotation = Quaternion.LookRotation(direction);
            var scale = Vector3.one * distance;

            StretchableDrawBatch.InstanceData instance = new StretchableDrawBatch.InstanceData
            {
                Transform = Matrix4x4.TRS(center, rotation, scale),
                NearColor = nearColor,
                FarColor = farColor,
                Thickness = thickness
            };

            if (Append(ref instance) == false) return;

            Encapsulate(start);
            Encapsulate(end);
        }
    }
}