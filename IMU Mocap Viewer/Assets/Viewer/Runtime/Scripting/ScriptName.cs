using TMPro;
using UnityEngine;

namespace Viewer.Runtime.Scripting
{
    [RequireComponent(typeof(TMP_Text))]
    public class ScriptName : MonoBehaviour
    {
        private TMP_Text text;

        private Color normalColor;
        [SerializeField] private Color disabledColor;

        private void Awake()
        {
            text = GetComponent<TMP_Text>();
            normalColor = text.color;

            ExternalProcess.Started += OnStarted;
            ExternalProcess.Stopped += OnStopped;

            Set(false);
        }

        private void OnDestroy()
        {
            ExternalProcess.Started -= OnStarted;
            ExternalProcess.Stopped -= OnStopped;
        }

        private void Update() => text.text = ScriptsOverlay.ScriptName;

        private void OnStarted() => Set(true);

        private void OnStopped() => Set(false);

        void Set(bool enabled) => text.color = enabled ? normalColor : disabledColor;
    }
}