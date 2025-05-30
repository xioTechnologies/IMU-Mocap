using UnityEngine;
using Viewer.Runtime.Primitives;

namespace Viewer.Runtime
{
    public sealed class Plotter : MonoBehaviour
    {
        [Header("Line")] [SerializeField] private LinePlotter line;

        [Header("Circle")] [SerializeField] private CirclePlotter circle;

        [Header("Dot")] [SerializeField] private DotPlotter dot;

        [Header("Axes")] [SerializeField] private AxesPlotter axes;

        [Header("Angle")] [SerializeField] private AnglePlotter angle;

        [Header("Label")] [SerializeField] private LabelPlotter labels;

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

            line.Plot(start, end);
        }

        public void Circle(Vector3 xyz, Vector3 axis, float radius)
        {
            bounds.Encapsulate(Utils.CircleBounds(xyz, axis, radius));

            circle.Plot(xyz, axis, radius);
        }

        public void Dot(Vector3 xyz, float size)
        {
            bounds.Encapsulate(xyz);

            dot.Plot(xyz, size);
        }

        public void Axes(Vector3 xyz, Quaternion quaternion, float scale)
        {
            bounds.Encapsulate(xyz);

            axes.Plot(xyz, quaternion, scale);
        }

        public void Angle(Vector3 xyz, Quaternion quaternion, float scale, AngleAndLimit? rotX, AngleAndLimit? rotY, AngleAndLimit? rotZ)
        {
            bounds.Encapsulate(new Bounds(xyz, Vector3.one * scale));

            angle.Plot(xyz, quaternion, rotX, rotY, rotZ, scale);
        }

        public void Label(Vector3 xyz, string text)
        {
            bounds.Encapsulate(xyz);

            labels.Plot(xyz, text, PlotterSettings.LabelColor);
        }
    }

    public struct AngleAndLimit
    {
        public float Angle;
        public float[] Limit;
    }
}