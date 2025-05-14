using UnityEngine;
using Unity.Mathematics;
using Viewer.Runtime.Primitives.Batching;

namespace Viewer.Runtime.Widgets
{
    public sealed class WorldGrid : MonoBehaviour
    {
        [Header("View")] [SerializeField] private Transform origin;
        [SerializeField] private float radius = 10f;
        [SerializeField, Range(0f, 1f)] private float fadeProportion = 0.5f;

        [Header("Drawing")] [SerializeField, Range(0, 255)]
        private int order = 1;

        [SerializeField] private int maxLineCount = 1000;
        [SerializeField] private Mesh lineMesh;
        [SerializeField] private Material material;

        [Header("Line Properties")] [SerializeField, Range(0f, 10f)]
        private float lineWidthPixels = 1f;

        [Header("Colors")] [SerializeField] private Color darkColor;
        [SerializeField] private Color majorLineColor;
        [SerializeField] private Color minorLineColor;
        [SerializeField] private Color xLineColor;
        [SerializeField] private Color yLineColor;

        private LineDrawBatch axisLines;
        private LineDrawBatch majorLines;
        private LineDrawBatch minorLines;

        private void OnValidate() => AssignOrder();

        private void AssignOrder()
        {
            if (minorLines == null) return;

            int localOrder = order;

            minorLines.Order = localOrder;
            majorLines.Order = ++localOrder;
            axisLines.Order = ++localOrder;
        }

        private void Awake()
        {
            axisLines = new LineDrawBatch(16, lineMesh, material, gameObject.layer);
            majorLines = new LineDrawBatch(maxLineCount, lineMesh, material, gameObject.layer);
            minorLines = new LineDrawBatch(maxLineCount, lineMesh, material, gameObject.layer);

            AssignOrder();
        }

        private void OnDestroy()
        {
            axisLines?.Dispose();
            majorLines?.Dispose();
            minorLines?.Dispose();
        }

        void Update()
        {
            axisLines.Clear();
            majorLines.Clear();
            minorLines.Clear();

            Color darkColorLinear = darkColor.linear;
            Color majorLineColorLinear = majorLineColor.linear;
            Color minorLineColorLinear = minorLineColor.linear;
            Color xLineColorLinear = xLineColor.linear;
            Color yLineColorLinear = yLineColor.linear;

            var center = origin.position / 10f;
            center.x = math.floor(center.x);
            center.y = math.floor(center.y);
            center.z = math.floor(center.z);
            center *= 10f;

            Vector3 min = center - Vector3.one._x0z() * (int)radius;
            Vector3 max = center + Vector3.one._x0z() * (int)radius;

            int countX = (int)(max.x - min.x) + 10;
            int countZ = (int)(max.z - min.z) + 10;

            var originPosition = origin.position;

            for (int x = 0; x <= countX + 1; x++)
            {
                var xLine = min + Vector3.forward._x0z() * x;

                var line = CalculateLine(originPosition, radius, fadeProportion, xLine, Vector3.right._x0z());

                if (line == null) continue;

                var absValue = Mathf.Abs(xLine.z);
                var isOrigin = absValue < 0.0001f;
                var isMajor = ((int)absValue % 10) == 0;
                var lineColor = Color.Lerp(darkColorLinear, isOrigin ? xLineColorLinear : isMajor ? majorLineColorLinear : minorLineColorLinear, line.Value.intensity);
                var batch = isOrigin ? axisLines : isMajor ? majorLines : minorLines;

                PlotFadedLine(line.Value, darkColorLinear, lineColor, batch);
            }

            for (int z = 0; z <= countZ + 1; z++)
            {
                var zLine = min + Vector3.right._x0z() * z;
                var line = CalculateLine(originPosition, radius, fadeProportion, zLine, Vector3.forward._x0z());

                if (line == null) continue;

                var absValue = Mathf.Abs(zLine.x);
                var isOrigin = absValue < 0.0001f;
                var isMajor = ((int)absValue % 10) == 0;
                var lineColor = Color.Lerp(darkColorLinear, isOrigin ? yLineColorLinear : isMajor ? majorLineColorLinear : minorLineColorLinear, line.Value.intensity);
                var batch = isOrigin ? axisLines : isMajor ? majorLines : minorLines;

                PlotFadedLine(line.Value, darkColorLinear, lineColor, batch);
            }

            axisLines.Draw();
            majorLines.Draw();
            minorLines.Draw();
        }

        private void PlotFadedLine((Vector3 min, Vector3 minFadeEnd, Vector3 maxFadeEnd, Vector3 max, float intensity) line, Color dark, Color color, LineDrawBatch lines)
        {
            float lineWidth = lineWidthPixels * PlotterSettings.PrimitiveScale;

            lines.Add(line.min._x0z(), line.minFadeEnd._x0z(), lineWidth, dark, color);

            lines.Add(line.minFadeEnd._x0z(), line.maxFadeEnd._x0z(), lineWidth, color, color);

            lines.Add(line.maxFadeEnd._x0z(), line.max._x0z(), lineWidth, color, dark);
        }

        private Vector3 ClosestPointOnLine(Vector3 center, Vector3 pointOnLine, Vector3 lineNormal)
        {
            Vector3 vectorToLine = center - pointOnLine;
            float t = Vector3.Dot(vectorToLine, lineNormal) / Vector3.Dot(lineNormal, lineNormal);
            return pointOnLine + t * lineNormal;
        }

        private (Vector3 min, Vector3 max)? LinePointsOnCircle(Vector3 center, float radius, Vector3 pointOnLine, Vector3 lineNormal)
        {
            Vector3 vectorToLine = pointOnLine - center;
            float a = Vector3.Dot(lineNormal, lineNormal);
            float b = 2 * Vector3.Dot(vectorToLine, lineNormal);
            float c = Vector3.Dot(vectorToLine, vectorToLine) - radius * radius;

            float discriminant = b * b - 4 * a * c;
            if (discriminant <= 0) return null;

            float sqrtDiscriminant = Mathf.Sqrt(discriminant);
            float t1 = (-b + sqrtDiscriminant) / (2 * a);
            float t2 = (-b - sqrtDiscriminant) / (2 * a);

            return (pointOnLine + t1 * lineNormal, pointOnLine + t2 * lineNormal);
        }

        private (Vector3 min, Vector3 minFadeEnd, Vector3 maxFadeEnd, Vector3 max, float intensity)? CalculateLine(
            Vector3 center, float radius, float fadeRadiusThreshold,
            Vector3 pointOnLine, Vector3 lineNormal
        )
        {
            var closest = ClosestPointOnLine(center, pointOnLine, lineNormal);
            var distance = Vector3.Distance(center, closest);
            var fadeStartRadius = radius * fadeRadiusThreshold;

            if (distance > radius) return null;

            if (distance >= fadeStartRadius)
            {
                var intensity = Mathf.Lerp(1f, 0f, (distance - fadeStartRadius) / (radius - fadeStartRadius));
                var fade = LinePointsOnCircle(center, radius, pointOnLine, lineNormal);
                if (fade == null) return null;

                var mid1 = Vector3.Lerp(fade.Value.min, fade.Value.max, 0.33f);
                var mid2 = Vector3.Lerp(fade.Value.min, fade.Value.max, 0.66f);

                return (fade.Value.min, mid1, mid2, fade.Value.max, intensity);
            }

            var points = LinePointsOnCircle(center, radius, pointOnLine, lineNormal);
            if (points == null) return null;

            var fadePoints = LinePointsOnCircle(center, fadeStartRadius, pointOnLine, lineNormal);
            if (fadePoints == null) return null;

            return (points.Value.min, fadePoints.Value.min, fadePoints.Value.max, points.Value.max, 1f);
        }
    }
}