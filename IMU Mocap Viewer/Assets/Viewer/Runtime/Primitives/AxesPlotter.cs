using UnityEngine;
using Viewer.Runtime.Draw;

namespace Viewer.Runtime.Primitives
{
    public sealed class AxesPlotter : MonoBehaviour
    {
        [SerializeField] private DrawingGroup group;

        [SerializeField] private int maxBoxCount = 1000;
        [SerializeField] private Mesh boxMesh;
        [SerializeField] private Material instanceMaterial;

        [SerializeField] private Color xColor = Color.red;
        [SerializeField] private Color yColor = Color.green;
        [SerializeField] private Color zColor = Color.blue;

        private StretchableDrawBatch boxes;

        private void Awake() => boxes = new StretchableDrawBatch(maxBoxCount, boxMesh, instanceMaterial);

        private void OnEnable() => group.RegisterSource(boxes);

        private void OnDisable() => group.UnregisterSource(boxes);

        private void OnDestroy() => boxes?.Dispose();

        public void Clear() => boxes?.Clear();

        public void Plot(Vector3 point, Quaternion rotation, float scale, float thickness)
        {
            void AddQuiver(Vector3 axis, Color color)
            {
                var quiverOffset = rotation * axis * scale;
                boxes?.AddLine(point, point + quiverOffset, thickness, color, color);
            }

            AddQuiver(Vector3.right, xColor);
            AddQuiver(Vector3.forward, yColor);
            AddQuiver(Vector3.up, zColor);
        }
    }
}