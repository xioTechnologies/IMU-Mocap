using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Viewer.Runtime.Draw;

namespace Viewer.Runtime.Widgets
{
    public sealed class WorldGrid : MonoBehaviour
    {
        [Header("View")] [SerializeField] private Transform origin;
        [SerializeField] private float radius = 10f;
        [SerializeField, Range(0f, 1f)] private float fadeProportion = 0.5f;

        [Header("Drawing")] [SerializeField] private DrawingGroup group;
        [SerializeField] private int maxLineCount = 1000;
        [SerializeField] private Mesh lineMesh;
        [SerializeField] private Material instanceMaterial;

        [Header("Line Properties")] [SerializeField, Range(0f, 10f)]
        private float lineWidthPixels = 1f;

        [Header("Colors")] [SerializeField] private Color darkColor;
        [SerializeField] private Color majorLineColor;
        [SerializeField] private Color minorLineColor;
        [SerializeField] private Color xLineColor;
        [SerializeField] private Color yLineColor;

        private StretchableDrawBatch lines;
        private new Camera camera;

        private void Awake()
        {
            lines = new StretchableDrawBatch(maxLineCount, lineMesh, instanceMaterial);
            camera = Camera.main;
        }

        private void OnEnable() => group.RegisterSource(lines);

        private void OnDisable() => group.UnregisterSource(lines);

        private void OnDestroy() => lines?.Dispose();

        void Update()
        {
            lines.Clear();

            var center = origin.position / 10f;
            center.x = math.floor(center.x);
            center.y = math.floor(center.y);
            center.z = math.floor(center.z);
            center *= 10f;

            Vector3 min = center - Vector3.one._x0z() * (int)radius;
            Vector3 max = center + Vector3.one._x0z() * (int)radius;

            int countX = (int)(max.x - min.x);
            int countZ = (int)(max.z - min.z);

            for (int x = 0; x <= countX + 1; x++)
            {
                var xLine = min + Vector3.forward._x0z() * x;
                var line = CalculateLine(origin.position, radius, fadeProportion, xLine, Vector3.right._x0z());

                if (line == null) continue;

                var absValue = Mathf.Abs(xLine.z);
                var isOrigin = absValue < 0.0001f;
                var isMajor = ((int)absValue % 10) == 0;
                var lineColor = Color.Lerp(darkColor, isOrigin ? xLineColor : isMajor ? majorLineColor : minorLineColor, line.Value.intensity);

                PlotFadedLine(line.Value, lineColor, camera.transform.position);
            }

            for (int z = 0; z <= countZ + 1; z++)
            {
                var zLine = min + Vector3.right._x0z() * z;
                var line = CalculateLine(origin.position, radius, fadeProportion, zLine, Vector3.forward._x0z());

                if (line == null) continue;

                var absValue = Mathf.Abs(zLine.x);
                var isOrigin = absValue < 0.0001f;
                var isMajor = ((int)absValue % 10) == 0;
                var lineColor = Color.Lerp(darkColor, isOrigin ? yLineColor : isMajor ? majorLineColor : minorLineColor, line.Value.intensity);

                PlotFadedLine(line.Value, lineColor, camera.transform.position);
            }
        }

        private void PlotFadedLine((Vector3 min, Vector3 minFadeEnd, Vector3 maxFadeEnd, Vector3 max, float intensity) line, Color color, Vector3 split)
        {
            float lineWidth = lineWidthPixels * PixelScaleUtility.DpiScaleFactor;

            var normal = (line.max._x0z() - line.min._x0z()).normalized;

            if (CrossesPlane(line.min._x0z(), line.minFadeEnd._x0z(), split, normal))
            {
                Vector3 intersection = GetIntersectionAndColor(
                    line.min, line.minFadeEnd,
                    darkColor, color,
                    split, normal,
                    out var intersectionColor
                );

                lines.AddLine(line.min._x0z(), intersection, lineWidth, darkColor, intersectionColor);
                lines.AddLine(intersection, line.minFadeEnd._x0z(), lineWidth, intersectionColor, color);
            }
            else
            {
                lines.AddLine(line.min._x0z(), line.minFadeEnd._x0z(), lineWidth, darkColor, color);
            }

            if (CrossesPlane(line.minFadeEnd._x0z(), line.maxFadeEnd._x0z(), split, normal))
            {
                var intersection = GetIntersection(line.minFadeEnd._x0z(), line.maxFadeEnd._x0z(), split, normal);
                lines.AddLine(line.minFadeEnd._x0z(), intersection, lineWidth, color, color);
                lines.AddLine(intersection, line.maxFadeEnd._x0z(), lineWidth, color, color);
            }
            else
            {
                lines.AddLine(line.minFadeEnd._x0z(), line.maxFadeEnd._x0z(), lineWidth, color, color);
            }

            if (CrossesPlane(line.maxFadeEnd._x0z(), line.max._x0z(), split, normal))
            {
                Vector3 intersection = GetIntersectionAndColor(
                    line.maxFadeEnd, line.max,
                    color, darkColor,
                    split, normal,
                    out var intersectionColor
                );

                lines.AddLine(line.maxFadeEnd._x0z(), intersection, lineWidth, color, intersectionColor);
                lines.AddLine(intersection, line.max._x0z(), lineWidth, intersectionColor, darkColor);
            }
            else
            {
                lines.AddLine(line.maxFadeEnd._x0z(), line.max._x0z(), lineWidth, color, darkColor);
            }
        }

        private Vector3 GetIntersectionAndColor(Vector3 min, Vector3 max, Color minColor, Color maxColor, Vector3 split, Vector3 normal, out Color intersectionColor)
        {
            var intersection = GetIntersection(min._x0z(), max._x0z(), split, normal);
            var t = (intersection - min._x0z()).magnitude / (max._x0z() - min._x0z()).magnitude;
            intersectionColor = Color.Lerp(minColor, maxColor, t);
            return intersection;
        }

        bool CrossesPlane(Vector3 a, Vector3 b, Vector3 split, Vector3 normal) => Vector3.Dot(a - split, normal) * Vector3.Dot(b - split, normal) < 0;

        Vector3 GetIntersection(Vector3 a, Vector3 b, Vector3 split, Vector3 normal)
        {
            float t = Vector3.Dot(split - a, normal) / Vector3.Dot(b - a, normal);
            return Vector3.Lerp(a, b, t);
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