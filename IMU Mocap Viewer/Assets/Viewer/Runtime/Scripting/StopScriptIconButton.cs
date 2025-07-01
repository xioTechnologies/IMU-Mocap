using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Viewer.Runtime.Scripting
{
    [RequireComponent(typeof(Button))]
    public class StopScriptIconButton : MonoBehaviour
    {
        private Button button;

        private void Awake()
        {
            button = GetComponent<Button>();

            button.onClick.AddListener(Stop);

            ExternalProcess.Started += OnStarted;
            ExternalProcess.Stopped += OnStopped;

            Set(false);
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(Stop);

            ExternalProcess.Started -= OnStarted;
            ExternalProcess.Stopped -= OnStopped;
        }

        private void Stop() => ExternalProcess.Stop();

        private void OnStarted() => Set(true);

        private void OnStopped() => Set(false);

        void Set(bool enabled) => button.interactable = enabled;
    }
}