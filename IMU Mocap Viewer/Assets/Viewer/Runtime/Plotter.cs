using UnityEngine;
using Viewer.Runtime.Primitives;

namespace Viewer.Runtime
{
    public sealed class Plotter : MonoBehaviour
    {
        [Header("Primitives")] [SerializeField, Range(0f, 10f)]
        private float primitiveScale = 3f;

        [Header("Line")] [SerializeField] private LinePlotter line;
        [SerializeField, Range(0f, 10f)] private float lineWidthInPixels = 1f;

        [Header("Circle")] [SerializeField] private CirclePlotter circle;
        [SerializeField, Range(0f, 10f)] private float circleLineWidthScaleFactor = 1f;

        [Header("Dot")] [SerializeField] private DotPlotter dot;
        [SerializeField, Range(0f, 10f)] private float dotSizeInPixels = 1f;

        [Header("Axes")] [SerializeField] private AxesPlotter axes;
        [SerializeField, Range(0f, 10f)] private float axesLineWidthInPixels = 1f;

        [Header("Label")] [SerializeField] private LabelPlotter labels;
        [SerializeField, Range(1f, 200f)] private float labelSizeInPoints = 20f;

        private bool hasBounds = false;

        private Bounds bounds;

        public Bounds Bounds => hasBounds ? bounds : new Bounds();

        private float DpiScaleFactor => primitiveScale * PixelScaleUtility.DpiScaleFactor;

        public bool IsEmpty => hasBounds == false;

        private void Encapsulate(Vector3 xyz)
        {
            if (hasBounds) bounds.Encapsulate(xyz);
            else bounds = new Bounds(xyz, Vector3.zero);

            hasBounds = true;
        }

        public void Clear()
        {
            hasBounds = false;

            line.Clear();
            circle.Clear();
            dot.Clear();
            axes.Clear();
            labels.Clear();
        }

        public void Line(Vector3 start, Vector3 end)
        {
            Encapsulate(start);
            Encapsulate(end);

            line.Plot(start, end, DpiScaleFactor * lineWidthInPixels);
        }

        public void Circle(Vector3 xyz, Vector3 axis, float radius)
        {
            Encapsulate(xyz);

            circle.Plot(xyz, axis, radius, DpiScaleFactor * lineWidthInPixels * circleLineWidthScaleFactor);
        }

        public void Dot(Vector3 xyz, float size)
        {
            Encapsulate(xyz);

            dot.Plot(xyz, size * DpiScaleFactor * dotSizeInPixels);
        }

        public void Axes(Vector3 xyz, Quaternion quaternion, float scale)
        {
            Encapsulate(xyz);

            axes.Plot(xyz, quaternion, scale, DpiScaleFactor * axesLineWidthInPixels);
        }

        public void Label(Vector3 xyz, string text)
        {
            Encapsulate(xyz);

            labels.Plot(xyz, DpiScaleFactor * labelSizeInPoints, text);
        }
    }
}