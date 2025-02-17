using UnityEngine;
using UnityEngine.Serialization;
using Viewer.Runtime.Draw;

namespace Viewer.Runtime.Primitives
{
    public sealed class AnglePlotter : MonoBehaviour
    {
        [SerializeField] private DrawingGroup group;

        [SerializeField] private int maxBoxCount = 1000;
        [SerializeField] private Mesh angleMesh;
        [SerializeField] private Material instanceMaterial;

        [SerializeField] private Color color = Color.red;

        [SerializeField, Range(0, 360)] private float angle = 360;

        private StretchableDrawBatch angles;

        private Color colorLinear;

        void CacheColors()
        {
            colorLinear = color.linear;
        }

#if UNITY_EDITOR
        void OnValidate() => CacheColors();
#endif

        private void Awake()
        {
            angles = new StretchableDrawBatch(maxBoxCount, angleMesh, instanceMaterial);
            CacheColors();
        }

        private void OnEnable() => group.RegisterSource(angles);

        private void OnDisable() => group.UnregisterSource(angles);

        private void OnDestroy() => angles?.Dispose();

        public void Clear() => angles?.Clear();

        public void Plot(Vector3 point, Vector3 axis, float radius, float thickness)
        {
            var angleColor = colorLinear;
            
            angleColor.a = angle / 360f; 
            
            angles?.AddBox(point, Quaternion.LookRotation(axis), radius * 2f, thickness, angleColor, colorLinear);
        }
    }
}