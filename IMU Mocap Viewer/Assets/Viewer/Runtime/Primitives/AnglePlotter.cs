using UnityEngine;
using Viewer.Runtime.Primitives.Batching;

namespace Viewer.Runtime.Primitives
{
    public sealed class AnglePlotter : MonoBehaviour
    {
        [SerializeField] private LabelPlotter labels;

        [SerializeField] private int maxCount = 1000;

        [SerializeField] private Mesh rangeMesh;
        [SerializeField] private Mesh needleMesh;
        [SerializeField] private Mesh valueMesh;

        [SerializeField] private Material material;

        [SerializeField, Range(0, 1)] private float valueAlpha = 0.2f;

        [SerializeField, Range(0, 255)] private int lineOrder = 2;
        [SerializeField, Range(0, 255)] private int valueOrder = 1;

        [SerializeField, Range(0f, 5f)] private float needleScale = 1;

        [SerializeField] private Color bendColor = Utils.ColorFromHex("FF9CAA");
        [SerializeField] private Color tiltColor = Utils.ColorFromHex("FFFF00");
        [SerializeField] private Color twistColor = Utils.ColorFromHex("5AFBF1");

        [SerializeField] private float labelMargin = 10f;

        private AngleDrawBatch ranges;
        private AngleDrawBatch needles;
        private AngleDrawBatch values;

        private Color bendColorLinear;
        private Color tiltColorLinear;
        private Color twistColorLinear;

        private Color bendAlphaLinear;
        private Color tiltAlphaLinear;
        private Color twistAlphaLinear;

        void CacheColors()
        {
            bendColorLinear = bendColor.linear;
            tiltColorLinear = tiltColor.linear;
            twistColorLinear = twistColor.linear;

            bendAlphaLinear = bendColorLinear;
            bendAlphaLinear.a = valueAlpha;

            tiltAlphaLinear = tiltColorLinear;
            tiltAlphaLinear.a = valueAlpha;

            twistAlphaLinear = twistColorLinear;
            twistAlphaLinear.a = valueAlpha;
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
            if (labels != null) labels.Clear();

            ranges?.Clear();
            needles?.Clear();
            values?.Clear();
        }

        public void Plot(Vector3 xyz, Quaternion quaternion, AngleAndLimit? rotX, AngleAndLimit? rotY, AngleAndLimit? rotZ, float scale)
        {
            float thickness = PlotterSettings.AngleLineWidthInPixels;

            var zRotation = Quaternion.AngleAxis(0, Vector3.up);
            var yRotation = Quaternion.AngleAxis(0, Vector3.right);
            var xRotation = Quaternion.AngleAxis(0, Vector3.forward);

            int inset = 6;
            float insetScale = 1f / inset * scale;

            bool hasLabels = labels != null;

            if (rotZ != null)
            {
                float angle = rotZ.Value.Angle;

                var rotationOffset = Quaternion.Euler(0, 0, 90);

                zRotation = Quaternion.AngleAxis(-angle, Vector3.up);

                var labelOffsetRotation = zRotation * rotationOffset;

                Add(
                    rotZ.Value,
                    quaternion * rotationOffset,
                    quaternion * labelOffsetRotation,
                    inset-- * insetScale,
                    twistColorLinear,
                    twistAlphaLinear,
                    twistColor
                );
            }

            if (rotY != null)
            {
                float angle = rotY.Value.Angle;

                var rotation = zRotation;

                yRotation = Quaternion.AngleAxis(-angle, Vector3.right);

                var labelOffsetRotation = rotation * yRotation;

                Add(
                    rotY.Value,
                    quaternion * rotation,
                    quaternion * labelOffsetRotation,
                    inset-- * insetScale,
                    tiltColorLinear,
                    tiltAlphaLinear,
                    tiltColor
                );
            }

            if (rotX != null)
            {
                float angle = rotX.Value.Angle;

                var rotation = zRotation * yRotation;

                xRotation = Quaternion.AngleAxis(angle, Vector3.forward); // why does this one need to be positive?! 

                Quaternion rotationOffset = Quaternion.Euler(0, 90, 0) * Quaternion.Euler(-90, 0, 0);

                var labelOffsetRotation = rotation * xRotation * rotationOffset;

                rotation *= rotationOffset;

                Add(
                    rotX.Value,
                    quaternion * rotation,
                    quaternion * labelOffsetRotation,
                    inset * insetScale,
                    bendColorLinear,
                    bendAlphaLinear,
                    bendColor
                );
            }

            void Add(AngleAndLimit data, Quaternion rotation, Quaternion labelOffsetRotation, float angleScale, Color color, Color alphaColor, Color labelColor)
            {
                float angle = data.Angle;

                values.Add(xyz, rotation, angleScale, thickness, alphaColor, Mathf.Min(angle, 0), Mathf.Max(angle, 0));

                needles.Add(xyz, rotation, angleScale, thickness * needleScale, color, angle, angle);

                float[] range = data.Limit;

                if (range is { Length: 2 }) ranges.Add(xyz, rotation, angleScale, thickness, color, range[0], range[1]);

                if (hasLabels)
                {
                    Vector3 direction = labelOffsetRotation * Vector3.forward;

                    Vector3 offset = direction * (angleScale * 0.5f);

                    labels.Plot(xyz + offset, labelColor, $"{angle:F1}°", direction, labelMargin);
                }
            }
        }

        void Update()
        {
            ranges?.Draw();
            needles?.Draw();
            values?.Draw();
        }
    }
}