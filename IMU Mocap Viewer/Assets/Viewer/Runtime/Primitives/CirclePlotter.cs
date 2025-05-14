using UnityEngine;
using Viewer.Runtime.Primitives.Batching;

namespace Viewer.Runtime.Primitives
{
    public sealed class CirclePlotter : MonoBehaviour
    {
        [SerializeField] private int maxBoxCount = 1000;
        [SerializeField] private Mesh torusMesh;
        [SerializeField] private Material instanceMaterial;
        [SerializeField] private Color color = Color.white;
        [SerializeField, Range(0, 255)] private int order = 1;

        private StretchableDrawBatch circles;
        private Color colorLinear;

        void CacheColors() => colorLinear = color.linear;

        void AssignOrder()
        {
            if (circles == null) return;

            circles.Order = order;
        }

        private void OnValidate()
        {
            CacheColors();
            AssignOrder();
        }

        private void Awake()
        {
            circles = new StretchableDrawBatch(maxBoxCount, torusMesh, instanceMaterial, gameObject.layer) { StencilMode = StencilMode.Stencil, };
            CacheColors();
            AssignOrder();
        }

        private void OnDestroy() => circles?.Dispose();

        public void Clear() => circles?.Clear();

        public void Plot(Vector3 xyz, Vector3 axis, float radius)
        {
            circles?.Add(xyz, Quaternion.LookRotation(axis), radius * 2f, PlotterSettings.CircleLineWidthInPixels, colorLinear, colorLinear);
            circles?.Encapsulate(Utils.CircleBounds(xyz, axis, radius));
        }

        void Update() => circles?.Draw();
    }
}