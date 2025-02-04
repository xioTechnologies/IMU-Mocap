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

        private void Awake() => rectTransform = GetComponent<RectTransform>();

        public void AdjustForCamera()
        {
            float worldSize = PixelScaleUtility.GetWorldSizeFromPixels(Scale * 10f, rectTransform.position);
            float worldMargin = PixelScaleUtility.GetWorldSizeFromPixels(Margin * 10f, rectTransform.position);

            text.fontSize = worldSize;
            text.margin = new Vector4(worldMargin, 0, 0, 0);

            rectTransform.localScale = Vector3.one;
            rectTransform.sizeDelta = new Vector2(text.preferredWidth, text.preferredHeight);
        }
    }
}