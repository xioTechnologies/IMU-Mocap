using UnityEngine;
using Viewer.Runtime.Primitives.Batching;

namespace Viewer.Runtime.Primitives
{
    public sealed class DotPlotter : MonoBehaviour
    {
        [SerializeField] private int maxBoxCount = 1000;
        [SerializeField] private Mesh dotMesh;
        [SerializeField] private Material instanceMaterial;
        [SerializeField] private Color color = Color.white;
        [SerializeField, Range(0, 255)] private int order = 1;

        private StretchableDrawBatch dots;
        private Color colorLinear;

        void CacheColors() => colorLinear = color.linear;

        void AssignOrder()
        {
            if (dots == null) return;

            dots.Order = order;
        }

        private void OnValidate()
        {
            CacheColors();
            AssignOrder();
        }

        private void Awake()
        {
            dots = new StretchableDrawBatch(maxBoxCount, dotMesh, instanceMaterial, gameObject.layer) { StencilMode = StencilMode.Stencil, };
            CacheColors();
            AssignOrder();
        }

        private void OnDestroy() => dots?.Dispose();

        public void Clear() => dots?.Clear();

        public void Plot(Vector3 xyz, float size) => dots?.Add(xyz, Quaternion.identity, 1f, size * PlotterSettings.DotSizeInPixels, colorLinear, colorLinear);

        void Update() => dots?.Draw();
    }
}