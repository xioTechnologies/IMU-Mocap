using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

namespace Viewer.Runtime.Draw
{
    sealed class DrawingRenderFeature : ScriptableRendererFeature
    {
        class PassData
        {
            public List<DrawingGroup> Groups;
        }

        class Pass : ScriptableRenderPass
        {
            private readonly DrawingRenderFeature feature;

            public Pass(DrawingRenderFeature feature) => this.feature = feature;

            public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
            {
                using var builder = renderGraph.AddRasterRenderPass<PassData>(feature.passName, out var passData);

                passData.Groups = feature.groups;

                var universalResourceData = frameData.Get<UniversalResourceData>();

                builder.SetRenderAttachment(universalResourceData.activeColorTexture, 0);
                builder.SetRenderAttachmentDepth(universalResourceData.activeDepthTexture);
                builder.AllowPassCulling(false);
                builder.SetRenderFunc((PassData data, RasterGraphContext context) =>
                {
                    RasterCommandBuffer cmd = context.cmd;

                    ClearDepthBuffer.AddCommands(cmd);

                    foreach (var group in data.Groups)
                    {
                        group.PopulateCommands(cmd);
                    }
                });
            }
        }

        [SerializeField] private RenderPassEvent renderPassEvent = RenderPassEvent.BeforeRenderingOpaques;
        [SerializeField] private string passName = "Draw Render Pass";
        [SerializeField] private List<DrawingGroup> groups = new();

        private Pass pass;

        public override void Create()
        {
            pass = new Pass(this)
            {
                renderPassEvent = renderPassEvent
            };
        }

        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
        {
            if (groups == null || groups.Count == 0)
                return;

            renderer.EnqueuePass(pass);
        }

        protected override void Dispose(bool disposing) => pass = null;
    }
}