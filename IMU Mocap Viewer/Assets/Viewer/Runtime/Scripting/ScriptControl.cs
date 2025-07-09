using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Viewer.Runtime.UI;

namespace Viewer.Runtime.Scripting
{
    [RequireComponent(typeof(Button), typeof(Tooltip))]
    public class ScriptControl : MonoBehaviour
    {
        [SerializeField] private TMP_Text scriptName;

        [SerializeField] private Sprite run;
        [SerializeField] private Sprite stop;

        private Tooltip tooltip;
        private Button button;
        private Image icon;

        private void Awake()
        {
            tooltip = GetComponent<Tooltip>();
            button = GetComponent<Button>();

            var graphic = button.targetGraphic;

            icon = (Image)graphic;

            button.onClick.AddListener(Clicked);

            ExternalProcess.Started += OnStarted;
            ExternalProcess.Stopped += OnStopped;

            Set(false);
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(Clicked);

            ExternalProcess.Started -= OnStarted;
            ExternalProcess.Stopped -= OnStopped;
        }

        private void OnStarted() => Set(true);

        private void OnStopped() => Set(false);

        void Set(bool running)
        {
            button.interactable = running || ExternalProcess.CanRerun;

            icon.sprite = running ? stop : run;

            scriptName.color = ExternalProcess.CanRerun ? button.colors.normalColor : button.colors.disabledColor;

            tooltip.TooltipText = running ? "Stop" : "Run";
        }

        private void Clicked()
        {
            if (ExternalProcess.Running) ExternalProcess.Stop();
            else ExternalProcess.Rerun();
        }

        private void Update()
        {
            ExternalProcess.Check();
            scriptName.text = ExternalProcess.ScriptName;
        }
    }
}