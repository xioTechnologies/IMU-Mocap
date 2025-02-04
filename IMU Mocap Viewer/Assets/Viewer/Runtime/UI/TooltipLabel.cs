using TMPro;
using UnityEngine;

namespace Viewer.Runtime.UI
{
    [RequireComponent(typeof(RectTransform))]
    public sealed class TooltipLabel : MonoBehaviour
    {
        private RectTransform labelTransform;
        private RectTransform textTransform;

        [SerializeField] private TMP_Text labelText;

        public void Show(string text, Vector2 position, Vector2 offset, Vector2 hoverOrigin, Vector2? positionOverride)
        {
            Vector2 canvasPosition = position;

            if (positionOverride != null)
            {
                canvasPosition = (hoverOrigin + positionOverride.Value);
            }

            if (labelTransform == null) labelTransform = GetComponent<RectTransform>();
            if (textTransform == null) textTransform = labelText.GetComponent<RectTransform>();

            Vector2 preferredValues = labelText.GetPreferredValues(text, float.PositiveInfinity, float.PositiveInfinity);

            Vector2 size = new Vector2(preferredValues.x, preferredValues.y);

            textTransform.sizeDelta = size;

            labelText.text = text;

            labelTransform.localPosition = canvasPosition + offset;

            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            labelText.text = "";
        }
    }
}