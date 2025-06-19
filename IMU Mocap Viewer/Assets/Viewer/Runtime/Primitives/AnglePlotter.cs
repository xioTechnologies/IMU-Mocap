using UnityEngine;
using Viewer.Runtime.Primitives.Batching;

namespace Viewer.Runtime.Primitives
{
    public sealed class AnglePlotter : MonoBehaviour
    {
        private static readonly Quaternion ZAlignment = Quaternion.identity;
        private static readonly Quaternion YAlignment = Quaternion.Euler(new(90, 0, 0)); // re-aligned to match the viewer's coordinate system
        private static readonly Quaternion XAlignment = Quaternion.Euler(new(0, -90, 0)) * Quaternion.Euler(new(-90, 0, 0)); // re-aligned to match the viewer's coordinate system

        [Header("Labels")] [SerializeField] private LabelPlotter labels;
        [SerializeField] private float labelMargin = 10f;

        [Header("Meshes")] [SerializeField] private int maxCount = 1000;
        [SerializeField] private Mesh rangeMesh;
        [SerializeField] private Mesh needleMesh;
        [SerializeField, Range(0f, 5f)] private float needleScale = 1;
        [SerializeField] private Mesh valueMesh;
        [SerializeField] private Material material;

        [Header("Order")] [SerializeField, Range(0, 255)]
        private int lineOrder = 2;

        [SerializeField, Range(0, 255)] private int valueOrder = 1;

        [Header("Colors")] [SerializeField] private Color xColor = Utils.ColorFromHex("FF9CAA");
        [SerializeField] private Color yColor = Utils.ColorFromHex("FFFF00");
        [SerializeField] private Color zColor = Utils.ColorFromHex("5AFBF1");
        [SerializeField] private Color genericColor = Utils.ColorFromHex("FFFFFF");
        [SerializeField, Range(0, 1)] private float valueAlpha = 0.2f;
        
        private AngleDrawBatch ranges;
        private AngleDrawBatch needles;
        private AngleDrawBatch values;

        private Color xColorLinear;
        private Color yColorLinear;
        private Color zColorLinear;
        private Color genericColorLinear;

        private Color xAlphaLinear;
        private Color yAlphaLinear;
        private Color zAlphaLinear;
        private Color genericAlphaLinear;

        void CacheColors()
        {
            xColorLinear = xColor.linear;
            yColorLinear = yColor.linear;
            zColorLinear = zColor.linear;
            genericColorLinear = genericColor.linear;

            xAlphaLinear = xColorLinear;
            xAlphaLinear.a = valueAlpha;

            yAlphaLinear = yColorLinear;
            yAlphaLinear.a = valueAlpha;

            zAlphaLinear = zColorLinear;
            zAlphaLinear.a = valueAlpha;

            genericAlphaLinear = genericColorLinear;
            genericAlphaLinear.a = valueAlpha;
        }

        private void AssignOrder()
        {
            if (values == null) return;

            values.Order = valueOrder;
            ranges.Order = lineOrder;
            needles.Order = lineOrder;
        }

        private void OnValidate()
        {
            CacheColors();

            AssignOrder();
        }

        private void Awake()
        {
            int layer = gameObject.layer;

            var localMaterial = new Material(material);

            localMaterial.EnableAngles(true);

            ranges = new AngleDrawBatch(maxCount, rangeMesh, localMaterial, layer) { StencilMode = StencilMode.Stencil, };
            needles = new AngleDrawBatch(maxCount, needleMesh, localMaterial, layer) { StencilMode = StencilMode.Stencil, };
            values = new AngleDrawBatch(maxCount, valueMesh, localMaterial, layer) { DrawType = DrawType.Transparent, StencilMode = StencilMode.Stencil, };

            CacheColors();
            AssignOrder();
        }

        private void OnDestroy()
        {
            ranges?.Dispose();
            needles?.Dispose();
            values?.Dispose();
        }

        public void Clear()
        {
            labels.Clear();

            ranges?.Clear();
            needles?.Clear();
            values?.Clear();
        }

        public void PlotAngle(Vector3 xyz, Quaternion quaternion, float angle, float scale)
        {
            Plot(xyz, quaternion, angle, null, scale * 2f, genericColorLinear, genericAlphaLinear, false);
        }

        public void PlotEuler(Vector3 xyz, Quaternion quaternion, AngleAndLimit? angleX, AngleAndLimit? angleY, AngleAndLimit? angleZ, float scale, bool mirror)
        {
            int inset = 6;
            float insetScale = 1f / inset * scale * 2f;

            var rotZ = angleZ.HasValue ? angleZ.Value.Angle : 0;
            var rotY = angleY.HasValue ? angleY.Value.Angle : 0;

            // Re-aligned to match the viewer's coordinate system
            var identity = Quaternion.identity; 
            var zRotation = Quaternion.Euler(new(0, -rotZ, 0));
            var yRotation = zRotation * Quaternion.Euler(new(0, 0, -rotY));

            PlotNext(xyz, quaternion * identity * ZAlignment, angleZ, ref inset, zColorLinear, zAlphaLinear);
            PlotNext(xyz, quaternion * zRotation * YAlignment, angleY, ref inset, yColorLinear, yAlphaLinear);
            PlotNext(xyz, quaternion * yRotation * XAlignment, angleX, ref inset, xColorLinear, xAlphaLinear);

            void PlotNext(Vector3 position, Quaternion rotation, AngleAndLimit? value, ref int ring, Color color, Color alphaColor)
            {
                if (value == null) return;

                Plot(position, rotation, value.Value.Angle, value.Value.Limit, ring-- * insetScale, color, alphaColor, mirror);
            }
        }

        void Update()
        {
            ranges?.Draw();
            needles?.Draw();
            values?.Draw();
        }

        private void Plot(Vector3 xyz, Quaternion quaternion, float angle, (float min, float max)? range, float scale, Color color, Color alphaColor, bool flip)
        {
            float angleScale = scale;
            float thickness = PlotterSettings.AngleLineWidthInPixels;

            var widgetRotation = quaternion * Quaternion.Euler(0, 90, 0) * Quaternion.Euler(0, 0, 90);
            var valueRotation = quaternion * Quaternion.Euler(0, 90 - angle, 0);

            values.Add(xyz, widgetRotation, angleScale, thickness, alphaColor, Mathf.Min(angle, 0), Mathf.Max(angle, 0), flip);
            needles.Add(xyz, widgetRotation, angleScale, thickness * needleScale, color, angle, angle, flip);

            if (range.HasValue) ranges.Add(xyz, widgetRotation, angleScale, thickness, color, range.Value.min, range.Value.max, flip);

            if (flip == true) valueRotation *= Quaternion.Euler(180, 0, 0);

            Vector3 direction = valueRotation * Vector3.forward;

            Vector3 offset = direction * (angleScale * 0.5f);

            labels.Plot(xyz + offset, color, $"{angle:F1}°", direction, labelMargin);
        }
    }
}