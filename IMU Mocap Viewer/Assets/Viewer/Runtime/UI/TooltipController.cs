using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Viewer.Runtime.UI
{
    public class TooltipController : MonoBehaviour
    {
        [SerializeField] private TooltipLabel tooltipLabel;
        [SerializeField] private float showForSeconds = 1f;
        [SerializeField] private Vector2 offset = new(0, 0);

        private RectTransform parentTransform;

        private float countdown;
        private bool isShowingTooltip;
        private Tooltip tooltipObject;

        private readonly List<RaycastResult> results = new();

        private Canvas canvas;

        private void Awake() => canvas = GetComponentInParent<Canvas>();

        private void Start() => parentTransform = tooltipLabel.transform.parent.GetComponent<RectTransform>();

        private void OnEnable() => tooltipLabel.Hide();

        private void OnDisable() => tooltipLabel.Hide();

        private void Update()
        {
            Tooltip tooltipUnderPointer = GetTooltipUnderPointer();

            if (ShouldKeepCurrentTooltip(tooltipUnderPointer)) return;

            tooltipLabel.Hide();

            isShowingTooltip = false;

            if (tooltipUnderPointer == null) return;

            Vector2 mousePosition = Mouse.current.position.ReadValue();

            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                parentTransform,
                mousePosition,
                canvas.worldCamera,
                out var canvasPosition
            );

            tooltipLabel.Show(
                tooltipUnderPointer.TooltipText,
                canvasPosition,
                offset,
                parentTransform.InverseTransformPoint(tooltipUnderPointer.transform.position),
                tooltipUnderPointer.HoverOffset
            );

            tooltipObject = tooltipUnderPointer;
            isShowingTooltip = true;
        }

        private bool ShouldKeepCurrentTooltip(Tooltip tooltipUnderPointer)
        {
            if (isShowingTooltip == false) return false;

            if (tooltipObject == tooltipUnderPointer)
            {
                countdown = showForSeconds;
                return true;
            }

            if (tooltipUnderPointer != null)
            {
                isShowingTooltip = false;
                return false;
            }

            countdown -= Time.deltaTime;

            isShowingTooltip = countdown > 0;

            return isShowingTooltip;
        }

        private Tooltip GetTooltipUnderPointer()
        {
            bool overObject = EventSystem.current.IsPointerOverGameObject();

            if (overObject == false) return null;

            Vector2 mousePosition = Mouse.current.position.ReadValue();

            PointerEventData pointerData = new PointerEventData(EventSystem.current) { position = mousePosition };

            EventSystem.current.RaycastAll(pointerData, results);

            foreach (RaycastResult result in results)
            {
                var tooltip = result.gameObject.GetComponentInParent<Tooltip>();

                if (tooltip == null) continue;

                return tooltip;
            }

            return null;
        }
    }
}