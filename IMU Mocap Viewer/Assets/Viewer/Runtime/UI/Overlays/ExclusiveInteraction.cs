using System.Collections.Generic;
using UnityEngine;
using Viewer.Runtime.Global;

namespace Viewer.Runtime.UI.Overlays
{
    [DefaultExecutionOrder(-1000)] // execute before OverlayButton 
    public class ExclusiveInteraction : MonoBehaviour
    {
        [SerializeField] private GlobalSetting worldSceneInteractable;

        [SerializeField] private List<GlobalSetting> overlays;

        private GlobalSetting active;

        private void Awake()
        {
            foreach (var overlay in overlays)
            {
                overlay.OnValueChanged += value => OverlayChanged(overlay, value); // delegate may not be disposed
            }
        }

        private void OnEnable()
        {
            worldSceneInteractable.Value = true;

            foreach (var overlay in overlays)
            {
                overlay.Value = false;
            }
        }

        void Update()
        {
            var any = false;

            foreach (var overlay in overlays)
            {
                any |= overlay.Value;
            }

            worldSceneInteractable.Value = any == false;
        }

        private void OverlayChanged(GlobalSetting subject, bool enabled)
        {
            if (enabled == false) return;

            foreach (var overlay in overlays)
            {
                var newValue = subject.Equals(overlay);

                if (overlay.Value != newValue) overlay.Value = newValue;
            }
        }
    }
}