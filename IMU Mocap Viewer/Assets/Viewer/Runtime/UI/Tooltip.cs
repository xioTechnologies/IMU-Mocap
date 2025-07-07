using UnityEngine;

namespace Viewer.Runtime.UI
{
    public sealed class Tooltip : MonoBehaviour
    {
        [SerializeField] private string tooltipText;
        [SerializeField] private bool useHoverOffset;
        [SerializeField] private Vector2 hoverOffset;

        public string TooltipText
        {
            get => tooltipText;
            set => tooltipText = value;
        }

        public Vector2? HoverOffset => useHoverOffset ? hoverOffset : null;
    }
}