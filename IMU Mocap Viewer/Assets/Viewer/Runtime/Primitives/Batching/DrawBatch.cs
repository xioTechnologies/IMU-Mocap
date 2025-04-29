using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Viewer.Runtime.Primitives.Batching
{
    public abstract class DrawBatch<TInstance> : IDisposable where TInstance : struct
    {
        // private static readonly int InstancesProperty = Shader.PropertyToID("_Instances");
        // private static readonly int PixelScaleFactor = Shader.PropertyToID("_PixelScaleFactor");
        // private static readonly int StencilValue = Shader.PropertyToID("_StencilValue");
        // private static readonly int SrcBlend = Shader.PropertyToID("_SrcBlend");
        // private static readonly int DstBlend = Shader.PropertyToID("_DstBlend");
        // private static readonly int StencilComp = Shader.PropertyToID("_StencilComp");
        // private static readonly int StencilPass = Shader.PropertyToID("_StencilPass");

        private readonly int maxCount;

        private readonly Mesh mesh;
        private readonly Material material;
        private readonly MaterialPropertyBlock propertyBlock;

        private readonly TInstance[] instances;
        private readonly ComputeBuffer instanceBuffer;

        private DrawType drawType = DrawType.Opaque;
        private StencilMode stencilMode = StencilMode.Stencil;

        private int order;
        private int layer;

        private Bounds? bounds;
        private int activeCount;
        private bool isDirty;

        public DrawBatch(int max, Mesh mesh, Material material, int layer)
        {
            maxCount = max;
            this.mesh = mesh ?? throw new ArgumentNullException(nameof(mesh));
            this.material = new Material(material ?? throw new ArgumentNullException(nameof(material)));
            this.material.EnableKeyword("USE_STRUCTURED_BUFFER");
            this.layer = layer;

            instances = new TInstance[maxCount];
            instanceBuffer = new ComputeBuffer(maxCount, Marshal.SizeOf<TInstance>());

            propertyBlock = new MaterialPropertyBlock();

            isDirty = true;
        }

        public DrawType DrawType
        {
            get => drawType;
            set
            {
                drawType = value;
                Order = Order;
            }
        }

        public StencilMode StencilMode
        {
            get => stencilMode;
            set
            {
                stencilMode = value;
                Order = Order;
            }
        }

        public int Order
        {
            get => order;
            set
            {
                order = value;

                material.SetRenderOrder(drawType, order);
                material.ConfigureStencil(stencilMode, order);
                material.SetBlendMode(drawType);
            }
        }

        public void Clear()
        {
            activeCount = 0;
            bounds = null;
        }

        public void Dispose() => instanceBuffer?.Dispose();

        public void Draw()
        {
            if (activeCount <= 0) return;

            if (Utils.ConsumeFlag(ref isDirty)) Flush();

            RenderParams renderParams = new RenderParams(material)
            {
                worldBounds = bounds ?? default,
                matProps = propertyBlock,
                layer = layer,
            };

            Graphics.RenderMeshPrimitives(renderParams, mesh, 0, activeCount);
        }

        protected bool Append(ref TInstance instance)
        {
            if (activeCount >= maxCount) return false;

            instances[activeCount++] = instance;

            isDirty = true;

            return true;
        }

        public void Encapsulate(Vector3 position) => bounds.Encapsulate(position);

        public void Encapsulate(Bounds aabb) => bounds.Encapsulate(aabb);

        private void Flush()
        {
            if (activeCount <= 0) return;

            instanceBuffer.SetData(instances, 0, 0, activeCount);
            // propertyBlock.SetFloat(PixelScaleFactor, PixelScaleUtility.PixelScaleFactor);
            propertyBlock.SetBuffer(StretchableMaterial.InstancesProperty, instanceBuffer);
        }
    }
}