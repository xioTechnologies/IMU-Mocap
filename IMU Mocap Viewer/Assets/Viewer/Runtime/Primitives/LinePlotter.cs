using UnityEngine;
using Viewer.Runtime.Draw;

namespace Viewer.Runtime.Primitives
{
    public sealed class LinePlotter : MonoBehaviour
    {
        [SerializeField] private DrawingGroup group;

        [SerializeField] private int maxBoxCount = 1000;
        [SerializeField] private Mesh boxMesh;
        [SerializeField] private Material instanceMaterial;
        [SerializeField] private Color color = Color.white;

        private Color colorLinear;

        void CacheColors() => colorLinear = color.linear;

#if UNITY_EDITOR
        void OnValidate() => CacheColors();
#endif

        private StretchableDrawBatch boxes;

        private void Awake()
        {
            boxes = new StretchableDrawBatch(maxBoxCount, boxMesh, instanceMaterial);
            CacheColors();
        }

        private void OnEnable() => group.RegisterSource(boxes);

        private void OnDisable() => group.UnregisterSource(boxes);

        private void OnDestroy() => boxes?.Dispose();

        public void Clear() => boxes?.Clear();

        public void Plot(Vector3 start, Vector3 end, float thickness) => boxes?.AddLine(start, end, thickness, colorLinear, colorLinear);
    }
}