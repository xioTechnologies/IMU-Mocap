using UnityEngine;

namespace Viewer.Runtime.Primitives
{
    public sealed class LinePlotter : MonoBehaviour
    {
        [SerializeField] private int maxBoxCount = 1000;
        [SerializeField] private Mesh boxMesh;
        [SerializeField] private Material instanceMaterial;
        [SerializeField] private Color color = Color.white;
        [SerializeField, Range(0, 255)] private int stencilValue = 1;

        private StretchableDrawBatch lines;
        private Color colorLinear;

        void CacheColors() => colorLinear = color.linear;

#if UNITY_EDITOR
        void OnValidate() => CacheColors();
#endif

        private void Awake()
        {
            lines = new StretchableDrawBatch(maxBoxCount, boxMesh, instanceMaterial);
            CacheColors();
        }

        private void OnDestroy() => lines?.Dispose();

        public void Clear() => lines?.Clear();

        public void Plot(Vector3 start, Vector3 end, float thickness) => lines?.AddLine(start, end, thickness, colorLinear, colorLinear);

        void Update() => lines?.Draw();
    }
}