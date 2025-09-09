using System;
using TMPro;
using UnityEngine;
using Viewer.Runtime.Json;

namespace Viewer.Runtime.Primitives
{
    [RequireComponent(typeof(RectTransform))]
    public sealed class Label : MonoBehaviour
    {
        [SerializeField, Range(0f, 10f)] private float margin = 0.5f;

        [SerializeField] private TMP_Text text;

        private RectTransform rectTransform;
        private RectTransform parentTransform;

        private readonly char[] buffer = new char[128];
        private int bufferLength;

        public void SetText(ReadOnlySpan<char> textSpan)
        {
            if (bufferLength == textSpan.Length
                && textSpan.SequenceEqual(buffer.AsSpan(0, bufferLength)))
            {
                return;
            }

            int truncated = Math.Min(textSpan.Length, buffer.Length);

            textSpan.Slice(0, truncated).CopyTo(buffer);

            bufferLength = truncated;

            text.SetCharArray(buffer, 0, bufferLength);
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

        public Vector3 Position { get; set; }

        public int LastSiblingIndex { get; set; } = -1;

        public float Depth { get; set; }

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            parentTransform = rectTransform.parent.GetComponent<RectTransform>();
        }

        public void Hide() => gameObject.SetActive(false);

        public void AdjustForCamera()
        {
            gameObject.SetActive(true);

            Vector3 viewportPosition = PixelScaleUtility.WorldToViewportPoint(Position);

            if (viewportPosition.z < 0)
            {
                text.enabled = false;
                return;
            }

            Depth = viewportPosition.z;

            text.enabled = true;
            text.fontSize = PlotterSettings.LabelSizeInPoints;

            var position = Position;

            Vector2 baseScreenPoint = PixelScaleUtility.WorldToScreenPoint(position);
            Vector3 calculatedMargin;

            if (MarginDirection.HasValue)
            {
                Vector3 offsetWorldPos = Position + MarginDirection.Value.normalized;

                Vector2 offsetScreenPoint = PixelScaleUtility.WorldToScreenPoint(offsetWorldPos);

                Vector2 screenOffsetDir = (offsetScreenPoint - baseScreenPoint).normalized;

                calculatedMargin = screenOffsetDir * Margin;
            }
            else
            {
                calculatedMargin = new Vector3(Margin, 0, 0);
            }

            Vector3 screenPoint = PixelScaleUtility.WorldToScreenPoint(position) + calculatedMargin;

            screenPoint.x = Mathf.Round(screenPoint.x);
            screenPoint.y = Mathf.Round(screenPoint.y);

            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    parentTransform,
                    screenPoint,
                    null,
                    out var anchoredPosition))
            {
                rectTransform.anchoredPosition = anchoredPosition;
            }

            rectTransform.localScale = Vector3.one;

            var preferred = text.GetPreferredValues();

            if (Mathf.Abs(rectTransform.sizeDelta.x - preferred.x) > 0.1f ||
                Mathf.Abs(rectTransform.sizeDelta.y - preferred.y) > 0.1f)
            {
                rectTransform.sizeDelta = preferred;
            }
        }
    }
}