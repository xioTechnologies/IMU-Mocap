using UnityEngine;
using Viewer.Runtime.Draw;

namespace Viewer.Runtime.Primitives
{
    public sealed class DotPlotter : MonoBehaviour
    {
        [SerializeField] private DrawingGroup group;

        [SerializeField] private int maxBoxCount = 1000;
        [SerializeField] private Mesh dotMesh;
        [SerializeField] private Material instanceMaterial;
        [SerializeField] private Color color = Color.white;

        private Color colorLinear;

        void CacheColors() => colorLinear = color.linear;

#if UNITY_EDITOR
        void OnValidate() => CacheColors();
#endif

        private StretchableDrawBatch dots;

        private void Awake()
        {
            dots = new StretchableDrawBatch(maxBoxCount, dotMesh, instanceMaterial);
            CacheColors();
        }

        private void OnEnable() => group.RegisterSource(dots);

        private void OnDisable() => group.UnregisterSource(dots);

        private void OnDestroy() => dots?.Dispose();

        public void Clear() => dots?.Clear();

        public void Plot(Vector3 point, float radius) => dots?.AddBox(point, Quaternion.identity, 1f, radius, colorLinear, colorLinear);
    }
}