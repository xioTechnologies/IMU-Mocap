using TMPro;
using UnityEngine;

namespace Viewer.Runtime.Primitives
{
    [RequireComponent(typeof(RectTransform))]
    public sealed class Label : MonoBehaviour
    {
        [SerializeField, Range(1f, 200f)] private float scale = 20f;
        [SerializeField, Range(0f, 10f)] private float margin = 0.5f;

        [SerializeField] private TMP_Text text;

        private RectTransform rectTransform;

        public string Text
        {
            get => text.text;
            set => text.text = value;
        }

        public float Scale
        {
            get => scale;
            set => scale = value;
        }

        public float Margin
        {
            get => margin;
            set => margin = value;
        }

        public Color Color
        {
            get => text.color;
            set => text.color = value;
        }

        public Vector3? MarginDirection { get; set; }

        public Vector3? Position { get; set; }

        private void Awake() => rectTransform = GetComponent<RectTransform>();

        public void AdjustForCamera()
        {
            RectTransform rect = rectTransform;

            if (rect == null) return;

            var position = Position ?? rect.position;

            float worldMargin = PixelScaleUtility.GetWorldSizeFromPixels(Margin * 10f, position);

            var marginParameters = new Vector4(worldMargin, 0, 0, 0);

            if (Position.HasValue)
            {
                transform.position = Position.Value;
            }

            if (Position.HasValue && MarginDirection.HasValue)
            {
                var projected = Vector3.ProjectOnPlane(MarginDirection.Value, PixelScaleUtility.CameraForward).normalized;

                transform.position += (projected * worldMargin);

                marginParameters = Vector4.zero;
            }

            text.margin = marginParameters;

            float worldSize = PixelScaleUtility.GetWorldSizeFromPixels(Scale * 10f, rect.position);
            text.fontSize = worldSize;

            rect.localScale = Vector3.one;
            rect.sizeDelta = new Vector2(text.preferredWidth, text.preferredHeight);
        }
    }
}