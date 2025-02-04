using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Rendering;

namespace Viewer.Runtime.Draw
{
    public sealed class StretchableDrawBatch : IDisposable, ICommandSource
    {
        private static readonly int InstancesProperty = Shader.PropertyToID("_Instances");

        private readonly int maxCount;

        private readonly Mesh mesh;
        private readonly Material material;
        private readonly MaterialPropertyBlock propertyBlock;

        private readonly InstanceData[] instances;
        private readonly ComputeBuffer instanceBuffer;

        private Bounds bounds;
        private int activeCount;
        private bool isDirty;
        private static readonly int PixelScaleFactor = Shader.PropertyToID("_PixelScaleFactor");

        [StructLayout(LayoutKind.Sequential)]
        struct InstanceData
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

        public int Order { get; set; } = 0;

        public StretchableDrawBatch(int max, Mesh mesh, Material material)
        {
            maxCount = max;
            this.mesh = mesh ?? throw new ArgumentNullException(nameof(mesh));
            this.material = material ?? throw new ArgumentNullException(nameof(material));

            instances = new InstanceData[maxCount];
            instanceBuffer = new ComputeBuffer(maxCount, Marshal.SizeOf<InstanceData>());

            propertyBlock = new MaterialPropertyBlock();
            isDirty = true;
        }

        private void AppendInstance(Vector3 position, Quaternion rotation, Vector3 scale, float thickness, Color nearColor, Color farColor)
        {
            int index = activeCount;

            if (index >= maxCount) return;

            if (activeCount == 0) bounds = new Bounds(position, Vector3.zero);
            else bounds.Encapsulate(position);

            InstanceData instance = new InstanceData();

            instance.Transform = Matrix4x4.TRS(position, rotation, scale);
            instance.NearColor = nearColor;
            instance.FarColor = farColor;
            instance.Thickness = thickness;

            instances[index] = instance;

            activeCount = Mathf.Clamp(activeCount + 1, 0, maxCount);

            isDirty = true;
        }

        public void Clear() => activeCount = 0;

        public void AddLine(Vector3 start, Vector3 end, float thickness, Color nearColor, Color farColor)
        {
            if (thickness <= 0f) return;

            var distance = Vector3.Distance(start, end);

            if (distance <= 0.00001f) return;

            var direction = (end - start).normalized;
            var center = (start + end) / 2f;
            var rotation = Quaternion.LookRotation(direction);
            var scale = Vector3.one * distance;

            AppendInstance(center, rotation, scale, thickness, nearColor, farColor);
        }

        public void AddBox(Vector3 position, Quaternion rotation, float scale, float thickness, Color nearColor, Color farColor)
        {
            AppendInstance(position, rotation, Vector3.one * scale, thickness, nearColor, farColor);
        }

        public void Dispose() => instanceBuffer?.Dispose();

        public void Draw()
        {
            if (activeCount <= 0) return;

            if (Utils.ConsumeFlag(ref isDirty)) Flush();

            material.SetPass(0);
            Graphics.DrawMeshInstancedProcedural(
                mesh,
                0,
                material,
                bounds,
                activeCount,
                propertyBlock
            );
        }

        private void Flush()
        {
            if (activeCount <= 0) return;

            instanceBuffer.SetData(instances, 0, 0, activeCount);
            propertyBlock.SetFloat(PixelScaleFactor, PixelScaleUtility.PixelScaleFactor);
            propertyBlock.SetBuffer(InstancesProperty, instanceBuffer);
        }

        public void PopulateCommands(RasterCommandBuffer buffer)
        {
            if (activeCount <= 0) return;

            if (Utils.ConsumeFlag(ref isDirty)) Flush();

            buffer.DrawMeshInstancedProcedural(mesh, 0, material, 0, activeCount, propertyBlock);
        }
    }
}