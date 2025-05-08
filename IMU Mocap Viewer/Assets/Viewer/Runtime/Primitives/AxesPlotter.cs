using UnityEngine;
using UnityEngine.Serialization;
using Viewer.Runtime.Primitives.Batching;

namespace Viewer.Runtime.Primitives
{
    public sealed class AxesPlotter : MonoBehaviour
    {
        [FormerlySerializedAs("maxBoxCount"), SerializeField]
        private int maxCount = 1000;

        [FormerlySerializedAs("boxMesh"), SerializeField]
        private Mesh capsuleMesh;

        [SerializeField] private Material instanceMaterial;
        [SerializeField, Range(0, 255)] private int order = 1;

        [SerializeField] private Color xColor = Color.red;
        [SerializeField] private Color yColor = Color.green;
        [SerializeField] private Color zColor = Color.blue;

        private LineDrawBatch quivers;

        private Color xColorLinear;
        private Color yColorLinear;
        private Color zColorLinear;

        void CacheColors()
        {
            xColorLinear = xColor.linear;
            yColorLinear = yColor.linear;
            zColorLinear = zColor.linear;
        }

        void AssignOrder()
        {
            if (quivers == null) return;

            quivers.Order = order;
        }

        private void OnValidate()
        {
            CacheColors();
            AssignOrder();
        }

        private void Awake()
        {
            quivers = new LineDrawBatch(maxCount, capsuleMesh, instanceMaterial, gameObject.layer) { StencilMode = StencilMode.Stencil, };
            CacheColors();
            AssignOrder();
        }

        private void OnDestroy() => quivers?.Dispose();

        public void Clear() => quivers?.Clear();

        public void Plot(Vector3 xyz, Quaternion quaternion, float scale, float thickness)
        {
            void AddQuiver(Vector3 axis, Color color)
            {
                var quiverOffset = quaternion * axis * scale;
                quivers?.Add(xyz, xyz + quiverOffset, thickness, color, color);
            }

            AddQuiver(Vector3.right, xColorLinear);
            AddQuiver(Vector3.forward, yColorLinear);
            AddQuiver(Vector3.up, zColorLinear);
        }

        void Update() => quivers?.Draw();
    }
}