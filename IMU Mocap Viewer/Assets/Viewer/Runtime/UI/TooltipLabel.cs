using TMPro;
using UnityEngine;

namespace Viewer.Runtime.UI
{
    [RequireComponent(typeof(RectTransform))]
    public sealed class TooltipLabel : MonoBehaviour
    {
        private (Tooltip tooltip, Vector2 offset, Vector2 canvasPosition)? state = null;
        private RectTransform labelTransform;
        private RectTransform textTransform;

        [SerializeField] private TMP_Text labelText;

        public void Show(Tooltip tooltip, Vector2 position, Vector2 offset, Vector2 hoverOrigin, Vector2? positionOverride)
        {
            Vector2 canvasPosition = position;

            if (positionOverride != null) canvasPosition = (hoverOrigin + positionOverride.Value);

            if (labelTransform == null) labelTransform = GetComponent<RectTransform>();
            if (textTransform == null) textTransform = labelText.GetComponent<RectTransform>();

            state = (tooltip, offset, canvasPosition);

            UpdateFromState(true);

            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            state = null;
            labelText.text = "";
        }

        private void Update() => UpdateFromState(false);

        private void UpdateFromState(bool force)
        {
            if (state == null) return;

            (Tooltip tooltip, Vector2 offset, Vector2 canvasPosition) = state.Value;

            if (force == false && tooltip.TooltipText == labelText.text) return;

            Vector2 preferredValues = labelText.GetPreferredValues(tooltip.TooltipText, float.PositiveInfinity, float.PositiveInfinity);

            Vector2 size = new Vector2(preferredValues.x, preferredValues.y);

            textTransform.sizeDelta = size;

            labelText.text = tooltip.TooltipText;

            labelTransform.localPosition = canvasPosition + offset;
        }
    }
}