using UnityEngine;
using Viewer.Runtime.Draw;

namespace Viewer.Runtime.Primitives
{
    public sealed class CirclePlotter : MonoBehaviour
    {
        [SerializeField] private DrawingGroup group;

        [SerializeField] private int maxBoxCount = 1000;
        [SerializeField] private Mesh torusMesh;
        [SerializeField] private Material instanceMaterial;
        [SerializeField] private Color color = Color.white;

        private StretchableDrawBatch circles;

        private void Awake() => circles = new StretchableDrawBatch(maxBoxCount, torusMesh, instanceMaterial);

        private void OnEnable() => group.RegisterSource(circles);

        private void OnDisable() => group.UnregisterSource(circles);

        private void OnDestroy() => circles?.Dispose();

        public void Clear() => circles?.Clear();

        public void Plot(Vector3 point, Vector3 axis, float radius, float thickness) => circles?.AddBox(point, Quaternion.LookRotation(axis), radius * 2f, thickness, color, color);
    }
}