using UnityEngine;
using UnityEngine.UI;

namespace Viewer.Runtime.Global
{
    [RequireComponent(typeof(Toggle))]
    public class GlobalSettingToggle : MonoBehaviour
    {
        [SerializeField] private GlobalSetting setting;

        private Toggle toggle;

        private void Awake()
        {
            toggle = GetComponent<Toggle>();

            toggle.isOn = setting.Value;

            toggle.onValueChanged.AddListener(ToggleChanged);
            setting.OnValueChanged += SettingChanged;
        }

        private void OnDestroy()
        {
            toggle.onValueChanged.RemoveListener(ToggleChanged);
            setting.OnValueChanged -= SettingChanged;
        }

        private void SettingChanged(bool value)
        {
            if (toggle.isOn != value) toggle.isOn = value;
        }

        private void ToggleChanged(bool value)
        {
            if (setting.Value != value) setting.Value = value;
        }
    }
}