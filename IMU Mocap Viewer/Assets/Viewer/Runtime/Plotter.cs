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

        [Header("Angle")] [SerializeField] private AnglePlotter angle;
        [SerializeField, Range(0f, 10f)] private float angleLineWidthInPixels = 1f;

        [Header("Label")] [SerializeField] private LabelPlotter labels;
        [SerializeField] private Color labelColor = Utils.ColorFromHex("E4E4E4");
        [SerializeField, Range(1f, 200f)] private float labelSizeInPoints = 20f;

        private float DpiScaleFactor => primitiveScale * PixelScaleUtility.DpiScaleFactor;

        private Bounds? bounds;

        public Bounds Bounds => bounds ?? new Bounds();

        public bool IsEmpty => bounds == null;

        public void Clear()
        {
            bounds = null;

            line.Clear();
            circle.Clear();
            dot.Clear();
            axes.Clear();
            angle.Clear();
            labels.Clear();
        }

        public void Line(Vector3 start, Vector3 end)
        {
            bounds.Encapsulate(start);
            bounds.Encapsulate(end);

            line.Plot(start, end, DpiScaleFactor * lineWidthInPixels);
        }

        public void Circle(Vector3 xyz, Vector3 axis, float radius)
        {
            bounds.Encapsulate(Utils.CircleBounds(xyz, axis, radius));

            circle.Plot(xyz, axis, radius, DpiScaleFactor * lineWidthInPixels * circleLineWidthScaleFactor);
        }

        public void Dot(Vector3 xyz, float size)
        {
            bounds.Encapsulate(xyz);

            dot.Plot(xyz, size * DpiScaleFactor * dotSizeInPixels);
        }

        public void Axes(Vector3 xyz, Quaternion quaternion, float scale)
        {
            bounds.Encapsulate(xyz);

            axes.Plot(xyz, quaternion, scale, DpiScaleFactor * axesLineWidthInPixels);
        }

        public void Angle(Vector3 xyz, Quaternion quaternion, float scale, AngleAndLimit? rotX, AngleAndLimit? rotY, AngleAndLimit? rotZ)
        {
            bounds.Encapsulate(new Bounds(xyz, Vector3.one * scale));

            angle.Plot(xyz, quaternion, rotX, rotY, rotZ, scale, DpiScaleFactor * angleLineWidthInPixels, DpiScaleFactor * labelSizeInPoints);
        }

        public void Label(Vector3 xyz, string text)
        {
            bounds.Encapsulate(xyz);

            labels.Plot(xyz, text, labelColor, DpiScaleFactor * labelSizeInPoints);
        }
    }

    public struct AngleAndLimit
    {
        public float Angle;
        public float[] Limit;
    }
}