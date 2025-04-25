using UnityEngine;

namespace Viewer.Runtime.Primitives
{
    public sealed class DotPlotter : MonoBehaviour
    {
        [SerializeField] private int maxBoxCount = 1000;
        [SerializeField] private Mesh dotMesh;
        [SerializeField] private Material instanceMaterial;
        [SerializeField] private Color color = Color.white;
        [SerializeField, Range(0, 255)] private int stencilValue = 1;

        private StretchableDrawBatch dots;
        private Color colorLinear;

        void CacheColors() => colorLinear = color.linear;

#if UNITY_EDITOR
        void OnValidate() => CacheColors();
#endif

        private void Awake()
        {
            dots = new StretchableDrawBatch(maxBoxCount, dotMesh, instanceMaterial);
            CacheColors();
        }

        private void OnDestroy() => dots?.Dispose();

        public void Clear() => dots?.Clear();

        public void Plot(Vector3 point, float radius) => dots?.AddBox(point, Quaternion.identity, 1f, radius, colorLinear, colorLinear);

        void Update() => dots?.Draw();
    }
}