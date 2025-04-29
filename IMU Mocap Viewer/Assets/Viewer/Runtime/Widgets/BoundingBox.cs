using UnityEngine;
using Viewer.Runtime.Primitives;
using Viewer.Runtime.Primitives.Batching;

namespace Viewer.Runtime.Widgets
{
    public class BoundingBox : MonoBehaviour
    {
        [SerializeField] private int maxLineCount = 1000;
        [SerializeField] private Mesh lineMesh;
        [SerializeField] private Material instanceMaterial;

        [Header("Line Properties")] [SerializeField, Range(0f, 10f)]
        private float lineWidthPixels = 1f;

        [SerializeField] private Color color;

        [SerializeField, Range(0f, 1f)] private float quiverRatio = 0.2f;

        private LineDrawBatch lines;

        public Bounds Bounds { get; set; }

        private void Awake() => lines = new LineDrawBatch(maxLineCount, lineMesh, instanceMaterial, gameObject.layer) { StencilMode = StencilMode.None, Order = -500 }; // use a negative order to render non-stencil materials later

        private void OnDestroy() => lines?.Dispose();

        void Update()
        {
            lines.Clear();

            var min = Bounds.min;
            var max = Bounds.max;

            float lineWidth = lineWidthPixels * PixelScaleUtility.DpiScaleFactor;

            var size = max - min;

            float shortestEdge = Mathf.Min(size.x, Mathf.Min(size.y, size.z));

            float quiverLength = shortestEdge * quiverRatio;

            var p0 = new Vector3(min.x, min.y, min.z);
            var p1 = new Vector3(max.x, min.y, min.z);
            var p2 = new Vector3(max.x, min.y, max.z);
            var p3 = new Vector3(min.x, min.y, max.z);

            var p4 = new Vector3(min.x, max.y, min.z);
            var p5 = new Vector3(max.x, max.y, min.z);
            var p6 = new Vector3(max.x, max.y, max.z);
            var p7 = new Vector3(min.x, max.y, max.z);

            DrawEdge(p0, p1, lineWidth, quiverLength);
            DrawEdge(p1, p2, lineWidth, quiverLength);
            DrawEdge(p2, p3, lineWidth, quiverLength);
            DrawEdge(p3, p0, lineWidth, quiverLength);

            DrawEdge(p4, p5, lineWidth, quiverLength);
            DrawEdge(p5, p6, lineWidth, quiverLength);
            DrawEdge(p6, p7, lineWidth, quiverLength);
            DrawEdge(p7, p4, lineWidth, quiverLength);

            DrawEdge(p0, p4, lineWidth, quiverLength);
            DrawEdge(p1, p5, lineWidth, quiverLength);
            DrawEdge(p2, p6, lineWidth, quiverLength);
            DrawEdge(p3, p7, lineWidth, quiverLength);

            lines.Draw();
        }

        private void DrawEdge(Vector3 start, Vector3 end, float lineWidth, float quiverLength)
        {
            var distance = Vector3.Distance(start, end);

            if (distance < quiverLength * 2)
            {
                lines.Add(start, end, lineWidth, color, color);
                return;
            }

            var axis = (end - start).normalized;

            lines.Add(start, start + (axis * quiverLength), lineWidth, color, color);
            lines.Add(end, end - (axis * quiverLength), lineWidth, color, color);
        }

        public void Show() => gameObject.SetActive(true);

        public void Hide() => gameObject.SetActive(false);
    }
}