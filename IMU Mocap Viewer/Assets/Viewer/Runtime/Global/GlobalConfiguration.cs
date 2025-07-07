using System;
using System.Collections.Generic;
using UnityEngine;

namespace Viewer.Runtime.Global
{
    public class GlobalConfiguration : MonoBehaviour
    {
        [InfoBox("Settings persist in the player preferences"), SerializeField]
        private List<GlobalSetting> settings = new();

        private readonly Dictionary<GlobalSetting, Action<bool>> events = new();

        void Awake()
        {
            foreach (var setting in settings)
            {
                if (PlayerPrefs.HasKey(setting.ID)) setting.Value = PlayerPrefs.GetInt(setting.ID) != 0;

                Action<bool> settingEvent = value => PlayerPrefs.SetInt(setting.ID, value ? 1 : 0);

                events[setting] = settingEvent;

                setting.OnValueChanged += settingEvent;
            }
        }

        private void OnDestroy()
        {
            foreach (var setting in settings)
            {
                setting.OnValueChanged -= events[setting];
            }
        }
    }
}