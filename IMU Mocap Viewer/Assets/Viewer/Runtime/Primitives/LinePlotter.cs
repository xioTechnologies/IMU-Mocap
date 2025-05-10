using UnityEngine;
using Viewer.Runtime.Primitives.Batching;

namespace Viewer.Runtime.Primitives
{
    public sealed class LinePlotter : MonoBehaviour
    {
        [SerializeField] private int maxBoxCount = 1000;
        [SerializeField] private Mesh boxMesh;
        [SerializeField] private Material instanceMaterial;
        [SerializeField] private Color color = Color.white;
        [SerializeField, Range(0, 255)] private int order = 1;

        private LineDrawBatch lines;
        private Color colorLinear;

        private void CacheColors() => colorLinear = color.linear;

        private void AssignOrder()
        {
            if (lines == null) return;

            lines.Order = order;
        }

        private void OnValidate()
        {
            CacheColors();
            AssignOrder();
        }

        private void Awake()
        {
            lines = new LineDrawBatch(maxBoxCount, boxMesh, instanceMaterial, gameObject.layer) { StencilMode = StencilMode.Stencil, };
            CacheColors();
            AssignOrder();
        }

        private void OnDestroy() => lines?.Dispose();

        public void Clear() => lines?.Clear();

        public void Plot(Vector3 start, Vector3 end) => lines?.Add(start, end, PlotterSettings.LineWidthInPixels, colorLinear, colorLinear);

        public void Plot(Vector3 start, Vector3 end, float thickness) => lines?.Add(start, end, thickness, colorLinear, colorLinear);

        void Update() => lines?.Draw();
    }
}