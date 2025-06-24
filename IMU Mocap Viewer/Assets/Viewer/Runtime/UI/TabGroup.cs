using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Viewer.Runtime.Global;

namespace Viewer.Runtime.UI
{
    [DefaultExecutionOrder(-1000)] // execute before TabButton 
    public class TabGroup : MonoBehaviour
    {
        [SerializeField] private List<GlobalSetting> tabs;

        private GlobalSetting main;
        private GlobalSetting active;

        private void Awake()
        {
            foreach (var tab in tabs)
            {
                tab.OnValueChanged += value => TabChanged(tab, value);
            }

            if (tabs.Count == 0) return;

            main = tabs.First();
            active = null;
        }

        private void OnEnable()
        {
            if (tabs.Count > 0) TabChanged(main, true);
        }

        private void TabChanged(GlobalSetting tab, bool value)
        {
            if (tab.Value != value) tab.Value = value;

            if (value == false)
            {
                if (tab.Equals(main)) return;

                if (tab.Equals(active)) TabChanged(main, true);

                return;
            }

            active = tab;

            foreach (var other in tabs)
            {
                if (tab.Equals(other)) continue;

                other.Value = false;
            }
        }
    }
}