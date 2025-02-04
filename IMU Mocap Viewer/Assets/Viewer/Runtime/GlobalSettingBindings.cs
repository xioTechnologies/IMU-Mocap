using System;
using UnityEngine;
using UnityEngine.Serialization;
using Viewer.Runtime.Global;

namespace Viewer.Runtime
{
    public class GlobalSettingBindings : MonoBehaviour
    {
        private ViewerInputs viewerInputs;

        [SerializeField] private GlobalSetting paused;

        private void Awake()
        {
            viewerInputs = new ViewerInputs();

            viewerInputs.Enable();
        }

        private void OnDestroy() => viewerInputs.Dispose();

        private void Update() => paused.Value = viewerInputs.Plotter.Paused.ReadValue<float>() > 0.5f;
    }
}