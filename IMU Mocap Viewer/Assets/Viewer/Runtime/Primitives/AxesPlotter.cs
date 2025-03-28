using UnityEngine;

namespace Viewer.Runtime.Primitives
{
    public sealed class AxesPlotter : MonoBehaviour
    {
        [SerializeField] private int maxBoxCount = 1000;
        [SerializeField] private Mesh boxMesh;
        [SerializeField] private Material instanceMaterial;
        [SerializeField, Range(0, 255)] private int stencilValue = 1;

        [SerializeField] private Color xColor = Color.red;
        [SerializeField] private Color yColor = Color.green;
        [SerializeField] private Color zColor = Color.blue;

        private StretchableDrawBatch quivers;

        private Color xColorLinear;
        private Color yColorLinear;
        private Color zColorLinear;

        void CacheColors()
        {
            xColorLinear = xColor.linear;
            yColorLinear = yColor.linear;
            zColorLinear = zColor.linear;
        }

#if UNITY_EDITOR
        void OnValidate() => CacheColors();
#endif

        private void Awake()
        {
            quivers = new StretchableDrawBatch(maxBoxCount, boxMesh, instanceMaterial);
            CacheColors();
        }

        private void OnDestroy() => quivers?.Dispose();

        public void Clear() => quivers?.Clear();

        public void Plot(Vector3 point, Quaternion rotation, float scale, float thickness)
        {
            void AddQuiver(Vector3 axis, Color color)
            {
                var quiverOffset = rotation * axis * scale;
                quivers?.AddLine(point, point + quiverOffset, thickness, color, color);
            }

            AddQuiver(Vector3.right, xColorLinear);
            AddQuiver(Vector3.forward, yColorLinear);
            AddQuiver(Vector3.up, zColorLinear);
        }

        void Update() => quivers?.Draw();
    }
}