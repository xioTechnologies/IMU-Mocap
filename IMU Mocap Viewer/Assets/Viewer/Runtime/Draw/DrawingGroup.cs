using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using Viewer.Runtime.Global;

namespace Viewer.Runtime.Draw
{
    [CreateAssetMenu(menuName = "IMU Viewer/Drawing Group", fileName = "Drawing Group", order = -1000)]
    public sealed class DrawingGroup : ScriptableObject
    {
        private DrawingGroup runtime;
        private DrawingGroup Runtime => runtime ??= KeyedSingleton<DrawingGroup>.ResolveInstance(id, this);

        [SerializeField] private string id = Guid.NewGuid().ToString();

        private readonly List<ICommandSource> sources = new();

        private bool needsSort = true;

        private void OnEnable()
        {
            if (Runtime == this) Clear();
        }

        public void PopulateCommands(RasterCommandBuffer buffer) => Runtime.PopulateRuntimeCommands(buffer);

        private void PopulateRuntimeCommands(RasterCommandBuffer buffer)
        {
            if (Utils.ConsumeFlag(ref needsSort)) sources.Sort((a, b) => a.Order.CompareTo(b.Order));

            if (sources.Count == 0) return;

            foreach (var source in sources)
            {
                source.PopulateCommands(buffer);
            }

            ClearDepthBuffer.AddCommands(buffer);
        }

        public void Clear() => Runtime.sources.Clear();

        public void RegisterSource(ICommandSource source) => Runtime.sources.Add(source);

        public void UnregisterSource(ICommandSource source) => Runtime.sources.Remove(source);
    }
}