using System.Collections.Generic;
using UnityEngine;

namespace Viewer.Runtime.Global
{
    public class GlobalConfiguration : MonoBehaviour
    {
        [InfoBox("Settings persist in the player preferences"), SerializeField]
        private List<GlobalSetting> settings = new();

        void Awake()
        {
            foreach (var setting in settings)
            {
                if (PlayerPrefs.HasKey(setting.ID)) setting.Value = PlayerPrefs.GetInt(setting.ID) != 0;

                setting.OnValueChanged += value => PlayerPrefs.SetInt(setting.ID, value ? 1 : 0);
            }
        }
    }
}