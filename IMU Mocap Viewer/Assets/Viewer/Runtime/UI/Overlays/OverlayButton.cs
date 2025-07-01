using UnityEngine;
using UnityEngine.UI;
using Viewer.Runtime.Global;

namespace Viewer.Runtime.UI.Overlays
{
    public class OverlayButton : MonoBehaviour
    {
        [SerializeField] private GlobalSetting overlay;

        [SerializeField] private OverlayButtonAction action = OverlayButtonAction.Open;

        [SerializeField] private bool settingSetsToggleState;

        private Button button;
        private Toggle toggle;

        private void Awake()
        {
            button = GetComponent<Button>();

            if (button != null) button.onClick.AddListener(Clicked);

            toggle = GetComponent<Toggle>();

            if (toggle == null) return;

            toggle.onValueChanged.AddListener(Toggled);

            if (settingSetsToggleState) overlay.OnValueChanged += OverlayChanged;
        }

        private void OnDestroy()
        {
            if (button != null) button.onClick.RemoveListener(Clicked);

            if (toggle == null) return;

            toggle.onValueChanged.RemoveListener(Toggled);

            overlay.OnValueChanged -= OverlayChanged;
        }

        private void Clicked()
        {
            overlay.Value = action switch
            {
                OverlayButtonAction.Open => true,
                OverlayButtonAction.Close => false,
                OverlayButtonAction.Toggle => overlay.Value == false,
                _ => overlay.Value
            };
        }

        private void Toggled(bool value)
        {
            if (settingSetsToggleState)
            {
                if (overlay.Value != value) overlay.Value = value;
            }
            else
            {
                overlay.Value = true;
            }
        }

        private void OverlayChanged(bool value)
        {
            if (toggle.isOn != value) toggle.isOn = value;
        }
    }

    public enum OverlayButtonAction
    {
        Open,
        Close,
        Toggle
    }
}