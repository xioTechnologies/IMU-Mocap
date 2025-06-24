using UnityEngine;
using UnityEngine.UI;
using Viewer.Runtime.Global;

namespace Viewer.Runtime.UI
{
    public class TabButton : MonoBehaviour
    {
        [SerializeField] private GlobalSetting tab;
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

            if (settingSetsToggleState) tab.OnValueChanged += TabOnOnValueChanged;
        }

        private void OnDestroy()
        {
            if (button != null) button.onClick.RemoveListener(Clicked);

            if (toggle == null) return;

            toggle.onValueChanged.RemoveListener(Toggled);

            tab.OnValueChanged -= TabOnOnValueChanged;
        }

        private void Clicked()
        {
            tab.Value = true;
        }

        private void Toggled(bool value)
        {
            if (settingSetsToggleState)
            {
                if (tab.Value != value) tab.Value = value;
            }
            else
            {
                tab.Value = true;
            }
        }

        private void TabOnOnValueChanged(bool value)
        {
            if (toggle.isOn != value) toggle.isOn = value;
        }
    }
}